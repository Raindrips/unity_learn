using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour {
    public float speed = 10;        //�ٶ�
    public Rect boundary;   //�ƶ���Χ
    public float tilt = 5;      //��б�Ƕ�
        
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
        //��ȡ��������
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //�����ƶ��ٶ�
        var rigidbody = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

        Vector3 pos = rigidbody.position;
        //�������겻������Ļ
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
