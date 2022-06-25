using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {
    public GameObject[] fishPrefabs;
    public CoinControll coinControll;
    public Transform[] pathArray;
    void Start() {
        InvokeRepeating("CreateFish", 0,3);
    }

    //创建鱼群
    void CreateFish() {
        // 一次创建鱼的次数
        int fishCount = 3;
        for (int i = 0; i < fishCount; i++) {
            Invoke("SpawnFish", i * 0.2f);
        }
    }

    //创建单个鱼
    void SpawnFish() {

        int pathRandomIndex = Random.Range(0,pathArray.Length);
        int fishRandomIndex= Random.Range(0, fishPrefabs.Length);
       
        GameObject fish = Instantiate(fishPrefabs[fishRandomIndex]);
        var fishControl = fish.GetComponent<FishControll>();
        

        List<Vector2> list = new List<Vector2>();
        Transform path= pathArray[pathRandomIndex];
        for (int i = 0; i < path.childCount; i++) {
            Vector3 position = path.GetChild(i).position;
            list.Add(new Vector2(position.x, position.y));
        }

        fishControl.Init(list.ToArray());
    }
}
