using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scrips {
    public class ScoreView : MonoBehaviour {

        public Text scoreText;
        private uint score = 0;         //无符号整形
       
        public void AddScore() {
            score++;
            scoreText.text = score.ToString();
        }
    }
}