using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControll : MonoBehaviour {
    public GameObject coinPrefab;

    public GameObject coinTextPrefab;

    public Sprite numberSprite;

    public int currentValue = 500;


    void Start() {

    }


    void Update() {

    }

    void SpawnCoin(Vector3 position, int number) {
        var coin = Instantiate(coinPrefab);
        coin.transform.position = position;
        
         
    }
}
