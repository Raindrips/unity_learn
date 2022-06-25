using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour {
    public float speed = 0.3f;
    public Vector2 dest = Vector2.zero;

    public bool isSuper= false;
    private float superTime = 0;

    void Start() {
        dest = Vector2.zero;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            dest = Vector2.up;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            dest = Vector2.down;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            dest = Vector2.left;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            dest = Vector2.right;
        }
        GetComponent<Animator>().SetFloat("DirX", dest.x);
        GetComponent<Animator>().SetFloat("DirY", dest.y);
        superTime -= Time.deltaTime;
        if (superTime < 0) {
            superTime = 0;
            isSuper = false;
        }
    }

    private void FixedUpdate() {
        transform.Translate(dest * speed * Time.deltaTime, Space.World);
    }

    bool isValid(Vector2 dir) {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return hit.collider == GetComponent<Collider2D>();
    }

    
    public void SuperPac() {
        isSuper = true;
        superTime = 10;
    }
}
