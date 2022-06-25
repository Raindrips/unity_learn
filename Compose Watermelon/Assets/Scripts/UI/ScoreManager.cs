using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;
    private int score;

    private void Start() {
        score = 0;
    }

    public void AddScore(int add) {
        score += add;
        if (scoreText) {
            scoreText.text = score.ToString();
            MaxScore();
        }
    }

    private void  MaxScore() {
        int maxScore=PlayerPrefs.GetInt("maxScore");
        if (score > maxScore) {
            PlayerPrefs.SetInt("maxScore", score);
        }
    }
}
