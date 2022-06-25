using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour {
    
    public GameObject PinPrefab;

    void Start() {
        
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            spawnPin();
        }
    }

    void spawnPin() {
        Instantiate(PinPrefab,transform.position,transform.rotation);
    }

}
