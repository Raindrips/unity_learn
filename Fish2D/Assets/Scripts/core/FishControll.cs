using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControll : MonoBehaviour
{

    public float moveSpeed;         //移动速度
    public FishDate fishDate;       //鱼群数据

    private Vector2[] pathArray;     //路径组
    private int nowIndex;

    private bool isAlive=true;           //是否存活
    
    public void Init(Vector2[] paths) {
        nowIndex = 0;
        this.pathArray = paths;
        transform.position = pathArray[0];
    }
    void Start()
    {
        isAlive = true;
    }

    public void Hurt(int damage) {
        if (damage > 0) {
            fishDate.HP -= damage;
            if (fishDate.HP <= 0) {
                isAlive = false;
                var animator = this.GetComponent<Animator>();
                animator.SetBool("isAlive", false);
            }
        }
    }

    //死亡动画
    public void DieAnimation() {
        GoldSpawner.Instance.SpawnCoin(transform.position, fishDate.gold);
        Destroy(this.gameObject,0.2f);
    }

    private void FixedUpdate() {
        if (!isAlive) {
            return;
        }
        if (pathArray!=null&&nowIndex<pathArray.Length) {
            MovePath(pathArray[nowIndex]);
        }
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    void MovePath(Vector2 path) {
        // 鱼自己的坐标
        Vector2 position = transform.position;
        // 路径坐标-自己的坐标=方向
        Vector2 dirction = (path - position);

        //鱼群和终点的距离                  //Mathf.Abs 计算绝对值
        float distance = Mathf.Abs(position.magnitude-path.magnitude);

        //如果距离小于移动速度的时间差,就移动到下一个路径中
        //为什么 distance < 0  移速过快可能会出现鬼畜现象
        if (distance < moveSpeed * Time.deltaTime) {
            nowIndex++;
            return;
        }

        //旋转方向
        //transform.up = dirction;
        transform.up = Vector3.Lerp(transform.up,dirction,Time.deltaTime);    
    }
}
