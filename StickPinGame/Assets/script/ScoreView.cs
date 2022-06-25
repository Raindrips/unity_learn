using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    public Text scoreText;

    private uint score = 0;
     
    void AddScore() {
        score++;
        scoreText.text = score.ToString();
    }
}
