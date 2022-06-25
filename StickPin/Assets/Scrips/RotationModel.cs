using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationModel : MonoBehaviour
{
    //旋转速度
    public float roationSpeed= 90f;
    //是否开始,可以不写, 用enable替代
    public bool isStart = true;
    void Start()
    {
        
    }

    //反向旋转
    public void ReWise() {
        roationSpeed = -roationSpeed;
    }

    void Update()
    {
        if (!isStart) {
            return;
        }
        transform.Rotate(0, 0, roationSpeed * Time.deltaTime);
    }

}
