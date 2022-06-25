using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControll : MonoBehaviour
{
    
    void Start()
    {
        
    }

    //void Update()
    //{
        
    //}

    //游戏结束
    public void GameOver() {

        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("GameOver");
    }

    //重新启动
    public void Restart() {
        string nowScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nowScene);
    }
}
