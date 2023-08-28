using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private void Update() {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
}
