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

    // ������Ⱥ
    void CreateFish() {
        //һ��������Ⱥ�Ĵ���
        int fishCount = 3;
        for (int i = 0; i < fishCount; i++) {
            Invoke("SpawnFish", i * 0.4f);
        }
    }

    //����������
    void SpawnFish() {
        //�����������ȡ��һ��Ԫ��
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
