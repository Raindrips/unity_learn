using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponControll : MonoBehaviour {
    //�ӵ�Ԥ�Ƽ�
    public GameObject bulletPrefab;


    //�ӵ���ʱ
    public float delay = 0.2f;
    //������
    private float interval;

    //��̨�ȼ�
    private int level = 1;

    /// <summary>
    /// ��̨�ĵȼ����ֵ����Сֵ
    /// </summary>
    private int maxLevel = 7;
    private int minLevel = 1;

    private void Awake() {

    }

    void Start() {

    }

    void Update() {
        OnTouchDown();
        interval += Time.deltaTime;
    }

    private void OnTouchDown() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            //��ʱ�����UI�ϣ������е�����¼�������
            //Debug.Log("UI����");
            return;
        }
        float fire1 = Input.GetAxis("Fire1");
        if (fire1 >= 1 && interval > delay) {
            Vector3 direction = FllowMouseRotate();
            //�޸�����ĳ���
            transform.up = direction;
            SpawnBullet(direction);

            interval = 0;
        }
    }

    // ���������ת
    Vector3 FllowMouseRotate() {
        //��ȡ�����Ļ������λ��,z��Ϊ0
        Vector3 mouse = Input.mousePosition;
        // ��ȡ������������
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        // ��Ļ����������������,��ȡ��������ķ���
        Vector3 direction = mouse - position;
        //��Z����Ϊ0
        direction.z = 0f;
        return direction;
    }


    //�����ӵ�����
    void SpawnBullet(Vector3 direction) {
        if (!bulletPrefab) {
            Debug.LogError("bullet Prefab is null");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        var bulletControll = bullet.GetComponent<BulletControll>();
        bulletControll.Init(direction, level);
        bulletControll.SetLevel(level);
    }

    //�ȼ�+1
    public void Add() {
     


        ChangeLevel(level + 1);
    }

    //�ȼ� -1
    public void Sub() {
        ChangeLevel(level - 1);
    }

    public void ChangeLevel(int newLevel) {

        level = Mathf.Clamp(newLevel, minLevel, maxLevel);
        Debug.Log(this.level);
        var animator = GetComponent<Animator>();
        animator.SetInteger("level", level);
    }
}
