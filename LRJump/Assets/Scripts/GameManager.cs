using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public PathManager pathManager;
    public GameObject robot;
    public GameObject gameOverBoard;

    public Transform background;

    private int downCount = 0;

    void Start() {
        GameStart();
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            OnTouchStart();
        }
    }

    public void OnTouchStart() {
        Vector2 mousePosition = Input.mousePosition;
        if (mousePosition.x < Screen.width / 2) {
            JumpLeft();
        }
        else {
            JumpRight();
        }
    }

    public void JumpLeft() {
        Debug.Log("œÚ◊ÛÃ¯");
        var robotControl = robot.GetComponent<RobotController>();
        if (robotControl.isJumping) {
            return;
        }
        robotControl.TurnLeft();
        robotControl.Jump();
        pathManager.InitPath();
    }
    public void JumpRight() {

        Debug.Log("œÚ”“Ã¯");
        var robotControl = robot.GetComponent<RobotController>();
        if (robotControl.isJumping) {
            return;
        }
        robotControl.TurnRight();
        robotControl.Jump();

        pathManager.InitPath();
    }

    public void GameStart() {
        downCount = 0;
        pathManager.CreatePath(20);

        var rotbotControl = robot.GetComponent<RobotController>();

        rotbotControl.jumpFailedEvent += OnGameOver;
        rotbotControl.jumpOverEvent += OnJumpFinish;

        Transform first = pathManager.FirstPath;
        rotbotControl.current = first;

        PathController next = first.GetComponent<PathController>().next;
        rotbotControl.next = next.transform;

        rotbotControl.SetPosition();
    }

   
    public void MoveDown() {
        float intervalY = pathManager.IntervalY;
        EventManager instance = EventManager.Instance;
      
        downCount++;
        if (downCount>=50) {
            downCount = 0;
            instance.Invoke("Reset");
        }
        float y = background.position.y - intervalY;
        background.DOMoveY(y,0.25f);
      

    }

    private void OnJumpFinish() {
        MoveDown();
    }


    private void OnGameOver() {
        if (robot) {
            robot.SetActive(false);
        }
        if (gameOverBoard) {
            gameOverBoard.SetActive(true);
        }
    }

    public void OnRestart() {
        RecyleFactory.Instance.Clear();
        SceneManager.LoadScene(1);
    }
}
