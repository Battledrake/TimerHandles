using System;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeCreations.TimerHandles
{
    public class WorldTimerManager : MonoBehaviour
    {
        static public WorldTimerManager Instance;

        private Dictionary<TimerHandle, TimerData> _activeTimers = new Dictionary<TimerHandle, TimerData>();
        private List<TimerHandle> _timersToRemove = new List<TimerHandle>();

        private void Awake()
        {
            if (Instance != null)
            {
                DestroyImmediate(this.gameObject);
                return;
            }
            Instance = this;
        }

        private void Update()
        {
            foreach (var timer in _activeTimers)
            {
                if (timer.Value.timerStatus == ETimerStatus.Active)
                {
                    if (timer.Value.expireTime <= Time.time)
                    {
                        timer.Value.timerDelegate?.Invoke();

                        if (!timer.Value.isLooping)
                        {
                            _timersToRemove.Add(timer.Key);
                        }
                        else
                        {
                            timer.Value.expireTime = timer.Value.timerRate + Time.time;
                        }
                    }
                }
                else if (timer.Value.timerStatus == ETimerStatus.PendingRemoval)
                {
                    _timersToRemove.Add(timer.Key);
                }
            }
            RemoveTimers();
        }

        private void RemoveTimers()
        {
            foreach (var timerHandle in _timersToRemove)
            {
                _activeTimers.Remove(timerHandle);
                timerHandle.IsActive = false;
            }
            _timersToRemove.Clear();
        }

        public void SetTimer(TimerHandle handle, Action action, float timerRate, bool isLooping = false, float firstDelay = 0.0f)
        {
            if (!handle.IsActive)
            {
                handle.IsActive = true;
                TimerData newTimerData = new TimerData(isLooping, ETimerStatus.Active, timerRate, Time.time + timerRate + firstDelay, action);
                _activeTimers.Add(handle, newTimerData);
            }
        }

        public void StopTimer(TimerHandle handle)
        {
            if (handle.IsActive)
            {
                if (_activeTimers.ContainsKey(handle))
                {
                    _activeTimers[handle].timerStatus = ETimerStatus.PendingRemoval;
                }
            }
        }

        public void PauseTimer(TimerHandle handle)
        {
            if (handle.IsActive)
            {
                _activeTimers[handle].timerStatus = ETimerStatus.Paused;
                _activeTimers[handle].expireTime -= Time.time;
            }
        }

        public void UnPauseTimer(TimerHandle handle)
        {
            if (handle.IsActive)
            {
                _activeTimers[handle].timerStatus = ETimerStatus.Active;
                _activeTimers[handle].expireTime += Time.time;
            }
        }
    }
}
