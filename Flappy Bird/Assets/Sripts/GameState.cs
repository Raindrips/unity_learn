using UnityEditor;
using UnityEngine;

public enum GameState {
    Idle,
    Start,
    GameOver,
}

public class Globle {
    static public GameState gamestate = GameState.Idle;
    static public int score = 0;
}

