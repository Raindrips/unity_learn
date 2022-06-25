using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorModel : MonoBehaviour
{
    public float speed = -90f;

    public bool isStart = true;


    void Update()
    {
        if (!isStart) {
            return;
        }
        transform.Rotate(0,0,speed*Time.deltaTime);
    }
}
