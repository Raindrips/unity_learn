using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//小鸟
public class BirdController : MonoBehaviour
{

    public GameManganger gameManage;
    public PipeSpawner spawner;
    public float jumpHeight = 800;      //跳跃高度

    public float grivate = 50;          //设置重力

    public float bound = 220;           //屏幕外的位置

    public AudioClip flyingClip;        //飞行的音频片段
    public AudioClip dieClip;
    public AudioClip getScoreClip;      //获得分数


    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            flying();
        }
    }

    private void flying() {
        //跳跃
        var rigidbody = GetComponent<Rigidbody2D>();
        
        //游戏开始添加重力
        if (Globle.gamestate==GameState.Idle) {
            Globle.gamestate = GameState.Start;
            rigidbody.gravityScale = grivate;
            spawner.GameStart();
        }

        //游戏结束
        if (Globle.gamestate == GameState.GameOver) {
            return;
        }

        //不允许飞出屏幕外
        var rect = GetComponent<RectTransform>();
        if (rect.localPosition.y > bound) {
            return;
        }

        //添加一个力(需要持续添加)
        //rigidbody.AddForce(new Vector2(0, jumpHeight));

        //设置加速度,可以瞬间有效果
        rigidbody.velocity=new Vector2(0, jumpHeight);

        audioSource.clip = flyingClip;
        audioSource.Play();


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Tigger:"+collision.tag);
        if (Globle.gamestate!=GameState.Start) {
            return;
        }
        if (collision.tag == "Score") {
            gameManage.AddScore();
            audioSource.clip = getScoreClip;
            audioSource.Play();
        }
        if (collision.tag == "Pipe") {
            Debug.Log("Game Over");
            GameOver();
            //播放音效
        }
        
    }

    public void GameOver() {
     
        //小鸟落地
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0,-300);
        //水管停下,背景停下
        gameManage.GameOver();

        audioSource.clip = dieClip;
        audioSource.Play();
    }
}
