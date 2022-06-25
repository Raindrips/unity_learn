using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScorll : MonoBehaviour
{
    public float scorllSpeed;       //滚动速度

    private Vector3 initPosition;   //初始坐标

    void Start()
    {
        var rectTransfrom = GetComponent<RectTransform>();
        initPosition = rectTransfrom.position;
    }

    void Update()
    {
        //lossyScale 获取全局缩放
        var rectTransfrom = GetComponent<RectTransform>();

        float newX = Mathf.Repeat(Time.time*scorllSpeed,
            rectTransfrom.sizeDelta.x*rectTransfrom.lossyScale.x);
        rectTransfrom.position = initPosition + Vector3.left * newX;
    }
}
