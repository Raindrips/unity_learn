using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State;

public class Enemy : MonoBehaviour {

    private float v = -1;
    private float h;

    public GameObject explosionPrefab;

    //计时器
    private float timeVal;
    private float timeValChangeDirection;

    private Tank tank;

    private void Awake() {
        tank = GetComponent<Tank>();
    }

    void AutoChange() {
        if (timeValChangeDirection >= 4) {
            int num = Random.Range(0, 8);
            if (num > 5) {
                v = -1;
                h = 0;
            }
            else if (num == 0) {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2) {
                h = -1;
                v = 0;
            }
            else if (num > 2 && num <= 4) {
                h = 1;
                v = 0;
            }
            timeValChangeDirection = 0;
        }
        else {
            timeValChangeDirection += Time.fixedDeltaTime;
        }
    }

    //坦克的移动方法
    private void Move() {
        if (h != 0) {
            transform.Translate(Vector3.right * h * tank.Speed * Time.deltaTime, Space.World);
        }
        else {
            transform.Translate(Vector3.up * v * tank.Speed * Time.deltaTime, Space.World);
        }
        if (v < 0) {
            tank.dir = Dir.down;
        }
        else if (v > 0) {
            tank.dir = Dir.up;
        }
        else if (h < 0) {
            tank.dir = Dir.left;
        }
        else if (h > 0) {
            tank.dir = Dir.right;
        }
        tank.ChangeDir();
    }



    void Start() {

    }
    private void FixedUpdate() {       
        this.Move();   
    }

    void Update() {
        this.AutoChange();
        //攻击的时间间隔
        if (timeVal >= 3) {
            tank.Attack();
            this.timeVal = 0;
        }
        else {
            timeVal += Time.deltaTime;
        }
    }
    private void Die() {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            timeValChangeDirection = 4;
        }
    }
}
