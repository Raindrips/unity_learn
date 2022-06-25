using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameState {
    start,
    ready,
    run,
    gameover,
}

public class Game : MonoBehaviour {
    public GameObject Maze;
    public GameObject start;
    public GameObject GameOver;
    public GameObject win;

    //private bool isSuper;
    private GameState state;

    void Start() {

    }

    void Update() {

    }

    public void StartGame() {

    }
}
