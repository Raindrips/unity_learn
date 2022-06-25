  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSConfig : MonoBehaviour
{
    public int frame = 60;
    // 初始化的时候调用的
    private void Awake() {
        Application.targetFrameRate = frame;
    }
}
