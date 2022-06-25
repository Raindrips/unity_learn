using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawn : MonoBehaviour
{
    public GameObject pinPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            this.SpawnPin();
        }
    }

    void SpawnPin() {
         GameObject pin= Instantiate(pinPrefab,transform.position,transform.rotation);
        //var canvas = GameObject.FindObjectOfType<Canvas>();
        pin.transform.localScale = Vector3.one*2;
        pin.transform.SetParent(transform);
      
       
    }
}
