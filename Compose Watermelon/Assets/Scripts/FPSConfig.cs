  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSConfig : MonoBehaviour
{
    public int frame = 60;
    // ��ʼ����ʱ����õ�
    private void Awake() {
        Application.targetFrameRate = frame;
    }
}
