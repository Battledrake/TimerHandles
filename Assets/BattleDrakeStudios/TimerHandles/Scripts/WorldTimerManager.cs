using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleDrakeStudios.TimerHandles {
    public class WorldTimerManager : MonoBehaviour {
        static public WorldTimerManager instance;

        private Dictionary<TimerHandle, TimerData> activeTimers = new Dictionary<TimerHandle, TimerData>();

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != null) {
                Destroy(instance.gameObject);
            }
        }

        private void Update() {
            foreach (var timer in activeTimers.ToArray()) {
                if (timer.Value.timerStatus == ETimerStatus.Active) {
                    if (timer.Value.expireTime <= Time.time) {
                        timer.Value.timerDelegate?.Invoke();

                        if (!timer.Value.isLooping) {
                            RemoveTimer(timer.Key);
                        } else {
                            timer.Value.expireTime = timer.Value.timerRate + Time.time;
                        }
                    }
                } else if (timer.Value.timerStatus == ETimerStatus.PendingRemoval) {
                    RemoveTimer(timer.Key);
                }
            }
        }

        private void RemoveTimer(TimerHandle handle) {
            activeTimers.Remove(handle);
            handle.IsActive = false;
        }


        public void SetTimer(TimerHandle handle, Action action, float timerRate, bool isLooping = false, float firstDelay = 0.0f) {
            if (!handle.IsActive) {
                handle.IsActive = true;
                TimerData newTimerData = new TimerData(isLooping, ETimerStatus.Active, timerRate, Time.time + timerRate + firstDelay, action);
                activeTimers.Add(handle, newTimerData);
            }
        }

        public void StopTimer(TimerHandle handle) {
            if (handle.IsActive) {
                if (activeTimers.ContainsKey(handle)) {
                    activeTimers[handle].timerStatus = ETimerStatus.PendingRemoval;
                }
            }
        }

        public void PauseTimer(TimerHandle handle) {
            if (handle.IsActive) {
                activeTimers[handle].timerStatus = ETimerStatus.Paused;
                activeTimers[handle].expireTime -= Time.time;
            }
        }

        public void UnPauseTimer(TimerHandle handle) {
            if (handle.IsActive) {
                activeTimers[handle].timerStatus = ETimerStatus.Active;
                activeTimers[handle].expireTime += Time.time;
            }
        }
    }
}
