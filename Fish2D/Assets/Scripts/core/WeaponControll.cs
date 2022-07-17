using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponControll : MonoBehaviour
{
    //子弹预制件
    public GameObject bulletPrefab;


    //子弹延时
    public float delay = 0.2f;
    //发射间隔
    private float interval;

    //炮台等级
    private int level = 1;

    /// <summary>
    /// 炮台的等级最大值和最小值
    /// </summary>
    private int maxLevel = 7;
    private int minLevel = 1;

    private void Awake() {
     
    }

    void Start()
    {
        
    }

    void Update()
    {
        OnTouchDown();
        interval += Time.deltaTime;
    }

    private void OnTouchDown() {
        //点击的位置是在UI上则不执行代码
        if (EventSystem.current.IsPointerOverGameObject()) {
            Debug.Log("UI拦截");
            return;
        }
        float fire1 = Input.GetAxis("Fire1");
        if (fire1 >= 1&& interval>delay) {
            Vector3 direction = FllowMouseRotate();
            //修改物体的朝向
            transform.up = direction;
            SpawnBullet(direction);
            
            interval = 0;
        }
    }

    // 跟随鼠标旋转
    Vector3 FllowMouseRotate() {
        //获取鼠标屏幕的坐标位置,z轴为0
        Vector3 mouse = Input.mousePosition;
        // 获取物体世界坐标
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        // 屏幕坐标和物体坐标相减,获取两个坐标的方向
        Vector3 direction = mouse - position;
        // cos sin tan 
        //将Z轴置为0
        direction.z = 0f;

        return direction;
    }


    //创建子弹对象
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

    //等级+1
    public void Add() {
        ChangeLevel(level + 1);
    }

    //等级 -1
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
