using UnityEngine;

namespace BattleDrakeStudios.TimerHandles {
    public class TimerTester : MonoBehaviour {
        [SerializeField] private float handleTime;
        [SerializeField] private float timeBeforeStop;

        private FTimerHandle testHandler = new FTimerHandle();

        private void Start() {
            WorldTimerManager.instance.SetTimer(testHandler, WriteStuff, handleTime, true, 5.0f);
        }

        private void WriteStuff() {
            Debug.Log("Stuff");
        }
    }
}
