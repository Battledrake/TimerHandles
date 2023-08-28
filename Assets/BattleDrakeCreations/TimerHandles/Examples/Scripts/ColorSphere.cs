using UnityEngine;
using BattleDrakeCreations.TimerHandles;

public class ColorSphere : MonoBehaviour {
    [SerializeField] private float changeColorTime = 1.0f;

    private TimerHandle colorHandler = new TimerHandle();

    private Material sphereMaterial;

    private void Start() {
        sphereMaterial = GetComponent<Renderer>().material;

        WorldTimerManager.Instance.SetTimer(colorHandler, ChangeColor, changeColorTime, true);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.F)) {
            WorldTimerManager.Instance.PauseTimer(colorHandler);
        }
        if(Input.GetKeyUp(KeyCode.F)) {
            WorldTimerManager.Instance.UnPauseTimer(colorHandler);
        }
    }

    private void ChangeColor() {
        sphereMaterial.color = new Color(Random.Range(0, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
}
