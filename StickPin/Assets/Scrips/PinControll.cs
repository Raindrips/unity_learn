using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinControll : MonoBehaviour
{
   
    public float moveSpeed= 20.0f; 
    void Start()
    {
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.up * moveSpeed;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("trigger");
        //碰到球了
        if (collision.tag == "Finish") {
            // 链接球和针
            LinkPin(collision.gameObject);
            //添加分数
            var canvas= GameObject.FindObjectOfType<Canvas>();
            canvas.gameObject.SendMessage("AddScore");
        }
        //撞到其他针上了
        else if (collision.tag == "Respawn") {
            //调用游戏结束
            
            //当前使用的摄像机,如果有多个的话,不建议这样获取
            if (Camera.current) {
                Camera.current.gameObject.SendMessage("GameOver");
            }
            
        }
    }

    private void LinkPin(GameObject go) {
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.zero;
        transform.SetParent(go.transform.parent);
        Debug.Log(transform.position);
        Debug.Log(transform.rotation);
    }
}
