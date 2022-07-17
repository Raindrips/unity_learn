using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControll : MonoBehaviour
{
    public int frameRate = 60;
    void OnEnable()
    {
        Application.targetFrameRate = frameRate;
    }


}
