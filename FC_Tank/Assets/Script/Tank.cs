using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State;

namespace State {
    public enum Dir {
        up = 0,
        right,
        down,
        left,
    }
}

public class Tank : MonoBehaviour {
    public float Speed = 3;
    public Sprite[] spriteAnim;
    public GameObject bulletPrefab;
    public bool isPlayer;

    private SpriteRenderer sprite;
    public Dir dir;

    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeDir() {
        this.sprite.sprite = this.spriteAnim[(int)dir];

    }

    public void Attack() {
        GameObject bulletObj = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.dir = this.dir;
        bullet.IsPlayerBullect = isPlayer;
        Destroy(bulletObj, 10);
    }

    private void OnDestroy() {
        
    }
}
