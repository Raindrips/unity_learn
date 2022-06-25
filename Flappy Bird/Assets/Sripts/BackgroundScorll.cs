using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScorll : MonoBehaviour
{
    public float scorllSpeed;       //�����ٶ�

    private Vector3 initPosition;   //��ʼ����

    void Start()
    {
        var rectTransfrom = GetComponent<RectTransform>();
        initPosition = rectTransfrom.position;
    }

    void Update()
    {
        //lossyScale ��ȡȫ������
        var rectTransfrom = GetComponent<RectTransform>();

        float newX = Mathf.Repeat(Time.time*scorllSpeed,
            rectTransfrom.sizeDelta.x*rectTransfrom.lossyScale.x);
        rectTransfrom.position = initPosition + Vector3.left * newX;
    }
}
