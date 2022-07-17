using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{

    public GameObject[] fishPrefabArray;

    public Transform[] pathArray;
    
    void Start()
    {
        InvokeRepeating("CreateFish",0,3);
    }

    // 创建鱼群
    void CreateFish() {
        //一次生成鱼群的次数
        int fishCount = 3;
        for (int i = 0; i < fishCount; i++) {
            Invoke("SpawnFish", i * 0.4f);
        }
    }

    //创建单个鱼
    void SpawnFish() {
        //从数组里随机取出一个元素
        int fishIndex = Random.Range(0, fishPrefabArray.Length);
        int pathIndex = Random.Range(0,pathArray.Length);

        GameObject fish = Instantiate(fishPrefabArray[fishIndex]);
        var fishControll = fish.GetComponent<FishControll>();

        List<Vector2> list = new List<Vector2>();
        Transform paths = pathArray[pathIndex];
        for (int i = 0; i < paths.childCount; i++) {
            Vector2 position = paths.GetChild(i).position;
            list.Add(position);
        }

        fishControll.Init(list.ToArray());
    }
}
