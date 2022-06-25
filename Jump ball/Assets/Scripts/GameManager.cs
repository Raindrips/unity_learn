using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState
{
    Wait,
    Start,
    Pause,
    End,
}
//声明一个委托类型，它的实例引用一个方法

public class GameManager : MonoBehaviour
{
    public GameObject manager;
    public delegate void GameEvent(GameState gameState);
    public event GameEvent OnGameStart;



    private static GameManager instance;
    public static GameManager Current
    {
        get => instance;
    }

    private GameState gameState;
    public GameState currentState
    {
        get => gameState;
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameState = GameState.Wait;

    }

    public void GameStart()
    {

        gameState = GameState.Start;
        //BroadcastMessage("OnGameStart");
        if (OnGameStart != null)
        {
            OnGameStart(GameState.Start);
        }

        if (manager)
        {
            manager.GetComponent<UIManager>().MenuHide();
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        gameState = GameState.End;
        //BroadcastMessage("OnGameOver");
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

    }

    public void GamePause()
    {
        gameState = GameState.Pause;
        Time.timeScale = 0;
        //BroadcastMessage("OnGamePause");
    }

    public void GameResume()
    {
        gameState = GameState.Pause;
        Time.timeScale = 1;

    }

    void Update()
    {

    }
}
