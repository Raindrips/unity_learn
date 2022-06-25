using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State;




public class Player : MonoBehaviour {

    public GameObject defendEffect;
    private float defendTimeVal;

    private Tank tank;
    private bool isDefended;

    private void Awake() {
        tank = GetComponent<Tank>();
    }
    void Start() {
        defendTimeVal = 0;
    }

    void Update() {
        this.Attack();
        DefendedUpdate();
    }

    private void FixedUpdate() {
        this.Move();
    }


    private void Move() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (h != 0) {
            transform.Translate(Vector3.right * h * tank.Speed * Time.deltaTime, Space.World);
        }
        else {
            transform.Translate(Vector3.up * v * tank.Speed * Time.deltaTime, Space.World);
        }

        if (h > 0) {
            tank.dir = Dir.right;
        }
        else if (h < 0) {
            tank.dir = Dir.left;
        }
        else if (v > 0) {
            tank.dir = Dir.up;
        }
        else if (v < 0) {
            tank.dir = Dir.down;
        }
        tank.ChangeDir();
    }

    private void Attack() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            this.tank.Attack();
        }
    }

    public void Die() {
        if (isDefended) {
            return;
        }
        Destroy(this.gameObject);
        GameObject playerManage = GameObject.Find("PlayerManager");
        playerManage.GetComponent<PlayerManager>().isDead = true;
    }

    void Defended() {
        isDefended = true;
        this.defendTimeVal = 10;
    }

    private void DefendedUpdate() {
        //是否处于无敌状态
        if (isDefended) {
            defendEffect.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal <= 0) {
                isDefended = false;
                defendEffect.SetActive(false);
            }
        }
    }
}
