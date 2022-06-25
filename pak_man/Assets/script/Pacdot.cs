using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Glost:int {
    blink,

}

public class Pacdot : MonoBehaviour {

    public bool isSuper = false;

    void setSuper() {
        isSuper = true;
    }

    void Start() {

    }

    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Respawn") {
            
            Destroy(gameObject);
        }
        if (collision.gameObject.tag=="Player") {
            pickDot(collision.gameObject);
        }
    }

    void pickDot(GameObject go) {
        if (isSuper) {
            go.SendMessage("SuperPac");
        }
        Destroy(gameObject);
    }
}
