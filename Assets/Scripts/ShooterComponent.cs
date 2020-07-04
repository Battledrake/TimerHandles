using BattleDrakeStudios.TimerHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterComponent : MonoBehaviour {
    [SerializeField] private Bullet bullet;

    [SerializeField] private float shootDelay = 0.1f;

    private TimerHandle shootHandler = new TimerHandle();

    private bool canFire = true;

    private void Start() {
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            if (canFire) {
                Shoot();
            }
        }
    }

    private void Shoot() {
        canFire = false;
        GameObject newBullet = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Destroy(newBullet, 5f);

        WorldTimerManager.instance.SetTimer(shootHandler, () => canFire = true, shootDelay);
    }
}
