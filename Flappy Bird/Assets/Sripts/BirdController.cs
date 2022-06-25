using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//С��
public class BirdController : MonoBehaviour
{

    public GameManganger gameManage;
    public PipeSpawner spawner;
    public float jumpHeight = 800;      //��Ծ�߶�

    public float grivate = 50;          //��������

    public float bound = 220;           //��Ļ���λ��

    public AudioClip flyingClip;        //���е���ƵƬ��
    public AudioClip dieClip;
    public AudioClip getScoreClip;      //��÷���


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
        //��Ծ
        var rigidbody = GetComponent<Rigidbody2D>();
        
        //��Ϸ��ʼ�������
        if (Globle.gamestate==GameState.Idle) {
            Globle.gamestate = GameState.Start;
            rigidbody.gravityScale = grivate;
            spawner.GameStart();
        }

        //��Ϸ����
        if (Globle.gamestate == GameState.GameOver) {
            return;
        }

        //������ɳ���Ļ��
        var rect = GetComponent<RectTransform>();
        if (rect.localPosition.y > bound) {
            return;
        }

        //���һ����(��Ҫ�������)
        //rigidbody.AddForce(new Vector2(0, jumpHeight));

        //���ü��ٶ�,����˲����Ч��
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
            //������Ч
        }
        
    }

    public void GameOver() {
     
        //С�����
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0,-300);
        //ˮ��ͣ��,����ͣ��
        gameManage.GameOver();

        audioSource.clip = dieClip;
        audioSource.Play();
    }
}
