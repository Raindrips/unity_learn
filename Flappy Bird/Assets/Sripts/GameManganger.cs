using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManganger : MonoBehaviour {
    public GameObject BG;      //±³¾°½Úµã
    public GameObject foreground;   //Ç°¾°

    public PipeSpawner pipeSpawner;

    public Animation GameOverPanel;

    public TextGroup text;

    public Text endScore;
    public Text maxScore;

    private void Start() {
        text.text = "0";
        Globle.score = 0;
    }

    public void GameOver() {
        Globle.gamestate = GameState.GameOver;
        this.StopBG();
        this.StopPipe();
        Invoke("ShowGamePanel",1f);
        SetEndScore();
    }

    void SetEndScore() {
        endScore.text= Globle.score.ToString();
        int max = PlayerPrefs.GetInt("max-score");
        if (max < Globle.score) {
            PlayerPrefs.SetInt("max-score", Globle.score);
            max = Globle.score;
        }
        maxScore.text = max.ToString();
    }

    public void  AddScore() {
        Globle.score++;
        text.text = Globle.score.ToString();
    }

    public void StopBG() {
        BackgroundScorll[] socrllArray = BG.GetComponentsInChildren<BackgroundScorll>();
        foreach (var scorll in socrllArray) {
            scorll.enabled = false;
        }

        BackgroundScorll[] socrllArray2 = foreground.GetComponentsInChildren<BackgroundScorll>();
        foreach (var scorll in socrllArray2) {
            scorll.enabled = false;
        }
    }

    public void StopPipe() {
        pipeSpawner.Stop();
        Rigidbody2D[] pipeArray = pipeSpawner.gameObject.GetComponentsInChildren<Rigidbody2D>();
        foreach (var pipe in pipeArray) {
            pipe.velocity = new Vector2();
        }
    }

    public void RestartGame() {
        Globle.gamestate = GameState.Idle;
        SceneManager.LoadScene(1);
    }

    public void ShowGamePanel() {
        GameOverPanel.Play();
    }
}
