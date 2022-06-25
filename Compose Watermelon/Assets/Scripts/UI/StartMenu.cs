using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Text text;
    void Start()
    {
        int maxScore = PlayerPrefs.GetInt("maxScore");
        if (text) {
            text.text = maxScore.ToString();
        }
    }


    // 游戏开始
    public void GameStart() {
        //切换到需要的场景
        SceneManager.LoadScene(1);
    }

    public void GameExit() {
        Invoke("_Exit", 0.5f);
       
    }
    private void _Exit() {
        //检测是否是在编辑器模式下
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        //调用.Net中关闭功能
        Application.Quit();
#endif
    }


}
