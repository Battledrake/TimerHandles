using System;

namespace BattleDrakeStudios.TimerHandles {
    public enum ETimerStatus {
        Active,
        Paused,
        PendingRemoval
    }

    public class TimerData {
        public bool isLooping;
        public ETimerStatus timerStatus;
        public float timerRate;
        public double expireTime;
        public Action timerDelegate;

        public TimerData(bool isLooping, ETimerStatus timerStatus, float timerRate, double expireTime, Action timerDelegate) {
            this.isLooping = isLooping;
            this.timerStatus = timerStatus;
            this.timerRate = timerRate;
            this.expireTime = expireTime;
            this.timerDelegate = timerDelegate;
        }
    }
}