using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    public GameObject goldPrefab; 
    
    private static GoldSpawner instance;

   

    private void Awake() {
        instance = this;
    }

    public static GoldSpawner Instance {
        get => instance;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SpawnCoin(Vector3 position,int number) {
        for (int i = 0; i < 6; i++) {
            float offsetX = Random.Range(-2, 2);
            var coin = Instantiate(goldPrefab);
            position.x += offsetX;
            coin.transform.position = position;
        }
    }
}
