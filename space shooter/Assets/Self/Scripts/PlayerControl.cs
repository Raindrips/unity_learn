using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour {
    public float speed = 10;        //速度
    public Rect boundary;   //移动范围
    public float tilt = 5;      //倾斜角度
        
    private float nextFire;     
    public float fireRate;
    public GameObject shotPrefab;
    public Transform shotSpawn;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        shoot();
    }


    private void FixedUpdate() {
        move();
    }

    private void move() {
        //获取按键属性
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //设置移动速度
        var rigidbody = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

        Vector3 pos = rigidbody.position;
        //控制坐标不超过屏幕
        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            pos.y,
            Mathf.Clamp(rigidbody.position.z, boundary.yMin, boundary.yMax)
        );

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f,
            rigidbody.velocity.x * -tilt);
    }

    private void shoot() {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shotPrefab, shotSpawn.position, shotSpawn.rotation);
            //GetComponent<AudioSource>().Play();
        }
    }
}
