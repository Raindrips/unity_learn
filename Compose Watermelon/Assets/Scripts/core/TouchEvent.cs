using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEvent : MonoBehaviour
{
    
    public float interval = 1;

    public GameObject guideLine;

    public GameObject fruitPrefab;

    public Transform fruitGroup;

    public ScoreManager scoreManager;

    private bool _isCanDown;
    private bool isGameOver = false;



    void Start()
    {
        _isCanDown = true;
    }

    void Update()
    {
        if (isGameOver) {
            return;
        }
        OnTouchDown();
        onTouchMove();
        onTouchUp();
    }

    private void OnTouchDown() {
       
        if (Input.GetMouseButtonDown(0)) {
            guideLine.SetActive(true);
        }
    }

    private void onTouchMove() {
        Vector2 v2 = GetClickPositon();
        Vector3 v3 = guideLine.transform.localPosition;
        guideLine.transform.localPosition=new Vector3(v2.x, v3.y,v3.z);
    }

    private void onTouchUp() {
        if (Input.GetMouseButtonUp(0)) {
            guideLine.SetActive(false);
           
            //不能连续生成
            if (!this._isCanDown) {
                return;
            }
            _isCanDown = false;
            Invoke("DelayTime", this.interval);
            SpawnFruit();
        }
    }

    Vector2 GetClickPositon() {


        //Debug.Log("screen w:" + Screen.width + ", h:" + Screen.height);
        //Debug.Log("click pos x:" + pos.x + ",pos y:" + pos.y);

        //转换为局部坐标
        Vector2 pos = Input.mousePosition;
        float X = pos.x - Screen.width / 2f;
        float Y = pos.y - Screen.height / 2f;
        Vector2 tranPos = new Vector2(X, Y);
        return tranPos;
    }

    public void DelayTime() {
        _isCanDown = true;
    }

    // 
    public void SpawnFruit() {

        GameObject fruit = Instantiate(fruitPrefab);
        fruit.transform.SetParent(fruitGroup);
        
        Vector2 v2 = GetClickPositon();
        Vector3 v3 = fruit.transform.localPosition;
        fruit.transform.localPosition = new Vector3(v2.x, 300, v3.z);
        RandomFruit randomFruit = RandomFruit.instance;
        int addScore = ((int)randomFruit.NextType + 1) * 2;
        scoreManager.AddScore(addScore);
    }

    public void GameOver() {
        isGameOver = true;
    }
}
