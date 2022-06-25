using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject shotPrefab;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    void Start() {
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire() {
        Instantiate(shotPrefab, shotSpawn.position, shotSpawn.rotation);
        GetComponent<AudioSource>().Play();
    }
}