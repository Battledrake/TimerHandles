using BattleDrakeStudios.TimerHandles;
using UnityEngine;

public class ColorSphere : MonoBehaviour {
    [SerializeField] private float changeColorTime = 1.0f;

    private TimerHandle colorHandler = new TimerHandle();

    private float activeTimer;

    private Material sphereMaterial;

    private bool isChanging;

    private void Start() {
        sphereMaterial = GetComponent<Renderer>().material;

        WorldTimerManager.instance.SetTimer(colorHandler, ChangeColor, changeColorTime, true);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            WorldTimerManager.instance.PauseTimer(colorHandler);
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            WorldTimerManager.instance.UnPauseTimer(colorHandler);
        }
    }

    private void ChangeColor() {
        sphereMaterial.color = new Color(Random.Range(0, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
}
