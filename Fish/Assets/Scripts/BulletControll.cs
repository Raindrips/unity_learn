using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour
{
    public GameObject netPrefab = null;

    public Sprite[] bulletSprite;
    // �ƶ��ٶ�
    public float movedSpeed = 6.0f;
    // �˺�
    private float damage = 7;
    // �ӵ��ȼ�
    private int bulletLevel = 0;

    public void SetLevel(int level) {
        bulletLevel = level-1;
        if (bulletLevel < bulletSprite.Length) {
            var sprite = GetComponentInChildren<SpriteRenderer>();
            sprite.sprite = bulletSprite[bulletLevel];
        }
    }

    public void Init(Vector3 dirction,int level) {
        transform.up = dirction;
        SetLevel(level);
        damage = level;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.up*movedSpeed*Time.deltaTime);
    }

    //��ײ���
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag=="Fish") {
            SpawnNet();
            Destroy(gameObject,0.1f);
        }
    }

    //��������
    private void SpawnNet() {
        var net = Instantiate(netPrefab);
        net.transform.position = this.transform.position;
        var netControll = net.GetComponent<NetControll>();
        netControll.SetLevel(bulletLevel);
    }
}
