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


    // ��Ϸ��ʼ
    public void GameStart() {
        //�л�����Ҫ�ĳ���
        SceneManager.LoadScene(1);
    }

    public void GameExit() {
        Invoke("_Exit", 0.5f);
       
    }
    private void _Exit() {
        //����Ƿ����ڱ༭��ģʽ��
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        //����.Net�йرչ���
        Application.Quit();
#endif
    }


}
