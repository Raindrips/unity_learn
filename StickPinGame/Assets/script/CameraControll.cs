using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControll : MonoBehaviour
{
    public RotatorModel rotatorComp;
    public PinSpawner spawnerComp;

    void StartGame() {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("GameStart");
    }

    // 游戏结束
    public void GameOver() {
        rotatorComp.enabled = false;
        spawnerComp.enabled = false;

        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("GameOver");
    }

    // 重新启动
    public void Restart() {
        string nowScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nowScene);
    }
}
