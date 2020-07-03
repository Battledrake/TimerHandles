using BattleDrakeStudios.TimerHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSphere : MonoBehaviour
{
    private float changeColorTime = 1.0f;
    FTimerHandle colorShiftingTimer = new FTimerHandle();

    private Material sphereMaterial;

    private void Start() {
        sphereMaterial = GetComponent<Renderer>().material;

        WorldTimerManager.instance.SetTimer(colorShiftingTimer, ChangeColor, changeColorTime, true);
    }

    private void ChangeColor() {
        sphereMaterial.color = new Color(Random.Range(0, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
}
