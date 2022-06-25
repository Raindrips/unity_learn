using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ˮ�ܿ�����
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
        initPosition.x = Screen.width/2;              //x����Ļ�ұ�
        initPosition.y = Random.Range(MinY,MaxY);   //y���չʾ

        //��������
        var rect = GetComponent<RectTransform>();
        rect.localPosition = initPosition;

        //ˮ���ƶ�
        //  ��ȡ�ӽڵ���ȫ���ĸ�������
        Rigidbody2D[] rigbodyArray = GetComponentsInChildren<Rigidbody2D>();
        foreach (var rigidbody in rigbodyArray) {
            rigidbody.velocity = new Vector2(-speed,0);
        }
    }
}
