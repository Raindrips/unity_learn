using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinControll : MonoBehaviour {
    public float speed = 20.0f;
    private Rigidbody2D rigidbody2d;

    private bool isGameover = false;

    private void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    void Start() {
        rigidbody2d.velocity = Vector2.up * speed;
    }

    private void FixedUpdate() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Finish") {
            LinkPin(collision.gameObject);

        }
        if (collision.tag == "Player") {
            if (Camera.current) {
                Camera.current.gameObject.SendMessage("GameOver");
            }
        }
    }

    private void LinkPin(GameObject go) {
        rigidbody2d.velocity = Vector2.zero;
        transform.parent = this.gameObject.transform;
        go.SendMessage("AddScore");
        if (Random.Range(0.0f, 1f) > 0.5f) {
            go.GetComponent<RotatorModel>().speed *= -1;
        }
    }

}
