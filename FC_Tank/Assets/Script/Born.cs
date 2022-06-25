﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour {

    public GameObject playerPrefab;

    public GameObject[] enemyPrefabList;

    public bool createPlayer;
    void Start() {
        Invoke("BornTank", 1f);
        Destroy(gameObject, 1f);
    }

    private void BornTank() {
        if (createPlayer) {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        else {
            int num = Random.Range(0, this.enemyPrefabList.Length);
            Instantiate(enemyPrefabList[num], transform.position, Quaternion.identity);
        }

    }
}
