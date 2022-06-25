using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用来装饰初始化地图所需物体的数组。 地图清单
//0.老家 
//1.墙 
//2.障碍 
//3.出生效果 
//4.河流 
//5.草 
//6.空气墙
public enum ItemState {
    heart,
    wall,
    barriar,
    born,
    rivier,
    gress,
    air
}

//地图创建
public class MapCreator : MonoBehaviour {
    
    public GameObject[] item;

    //已经有东西的位置列表
    private List<Vector3> itemPositionList = new List<Vector3>();
    private void Awake() {
        InitMap();
    }
    public GameObject GetItem(ItemState state) {
        return item[(int)state];
    }
    private void InitMap() {
        //实例化老家
        CreateItem(ItemState.heart, new Vector3(0, -8, 0), Quaternion.identity);
        //用墙把老家围起来
        CreateItem(ItemState.wall, new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(ItemState.wall, new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = -1; i < 2; i++) {
            CreateItem(ItemState.wall, new Vector3(i, -7, 0), Quaternion.identity);
        }
        //实例化外围墙
        for (int i = -11; i < 12; i++) {
            CreateItem(ItemState.air, new Vector3(i, 9, 0), Quaternion.identity);
        }
        for (int i = -11; i < 12; i++) {
            CreateItem(ItemState.air, new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (int i = -8; i < 9; i++) {
            CreateItem(ItemState.air, new Vector3(-11, i, 0), Quaternion.identity);
        }
        for (int i = -8; i < 9; i++) {
            CreateItem(ItemState.air, new Vector3(11, i, 0), Quaternion.identity);
        }

        //初始化玩家
        GameObject go = Instantiate(item[3], new Vector3(-2, -8, 0), Quaternion.identity);
        go.GetComponent<Born>().createPlayer = true;

        //产生敌人
        CreateItem(ItemState.born, new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItem(ItemState.born, new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem(ItemState.born, new Vector3(10, 8, 0), Quaternion.identity);


        InvokeRepeating("CreateEnemy", 4, 5);

        //实例化地图
        for (int i = 0; i < 60; i++) {
            CreateItem(ItemState.wall, CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++) {
            CreateItem(ItemState.barriar, CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++) {
            CreateItem(ItemState.gress, CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++) {
            CreateItem(ItemState.gress, CreateRandomPosition(), Quaternion.identity);
        }
    }

    //产生随机位置的方法
    private Vector3 CreateRandomPosition() {
        //不生成x=-10,10的两列，y=-8,8正两行的位置
        while (true) {
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if (!HasThePosition(createPosition)) {
                return createPosition;
            }
        }
    }

    //产生敌人的方法
    private void CreateEnemy() {
        int num = Random.Range(0, 3);
        Vector3 EnemyPos = new Vector3();
        if (num == 0) {
            EnemyPos = new Vector3(-10, 8, 0);
        }
        else if (num == 1) {
            EnemyPos = new Vector3(0, 8, 0);
        }
        else {
            EnemyPos = new Vector3(10, 8, 0);
        }
        CreateItem(ItemState.born, EnemyPos, Quaternion.identity);
    }

    //创建地图
    private void CreateItem(ItemState state, Vector3 createPosition, Quaternion createRotation) {
        GameObject itemGo = Instantiate(GetItem(state), createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(createPosition);
    }

    //用来判断位置列表中是否有这个位置
    private bool HasThePosition(Vector3 createPos) {
        for (int i = 0; i < itemPositionList.Count; i++) {
            if (createPos == itemPositionList[i]) {
                return true;
            }
        }
        return false;
    }

}
