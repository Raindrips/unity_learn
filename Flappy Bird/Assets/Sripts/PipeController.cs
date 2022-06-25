using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//水管控制器
public class PipeController : MonoBehaviour
{
    public float MaxY = -200;

    public float MinY = -100;

    public float speed = 400;

    private bool isScore = false;
    void Start()
    {
        init();
    }

    public void init() {
        
        Vector3 initPosition = new Vector3();
        initPosition.x = Screen.width/2;              //x在屏幕右边
        initPosition.y = Random.Range(MinY,MaxY);   //y随机展示

        //设置坐标
        var rect = GetComponent<RectTransform>();
        rect.localPosition = initPosition;

        //水管移动
        //  获取子节点上全部的刚体属性
        Rigidbody2D[] rigbodyArray = GetComponentsInChildren<Rigidbody2D>();
        foreach (var rigidbody in rigbodyArray) {
            rigidbody.velocity = new Vector2(-speed,0);
        }
    }
}
