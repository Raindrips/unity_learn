using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel : MonoBehaviour
{
    public LevelData[] levelDatas;

    public GameObject circle;

    private int nowLevel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void LoadBigBall(float counts) {
        for (int i = 0; i < circle.transform.childCount; i++) {
            Destroy(circle.transform.GetChild(i).gameObject);
        }

       
    }
}
