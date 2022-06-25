using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State;

public class Bullet : MonoBehaviour {

    public Sprite[] sprites;
    public float speed = 8;
    public GameObject explosion;

    public Dir dir;


    private bool isPlayerBullect = false;
    public bool IsPlayerBullect {
        set {
            this.isPlayerBullect = value;
        }
    }

    void Start() {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[(int)dir];
    }


    void Update() {
        Move();
    }

    void FixedUpdate() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.tag);
        switch (collision.tag) {
            case "Player":
                if (!isPlayerBullect) {
                    Destroy(this.gameObject);
                    collision.SendMessage("Die");
                }
                break;
            case "Heart":
                collision.SendMessage("Die");
                Destroy(this.gameObject);

                break;
            case "Enemy":
                if (isPlayerBullect) {
                    collision.SendMessage("Die");
                    Destroy(this.gameObject);
                }

                break;
            case "Wall":
            case "Bullet":
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                break;
            case "Barrier":
                if (isPlayerBullect) {
                    collision.SendMessage("PlayAudio");
                }
                Destroy(this.gameObject);
                break;
           
          
            default:
                break;
        }
    }

    private void Move() {
        switch (dir) {
            case Dir.up:
                transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
                break;
            case Dir.right:
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
                break;
            case Dir.down:
                transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
                break;
            case Dir.left:
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
                break;
            default:
                break;
        }
        //transform.position = v3;
    }

    private void OnDestroy() {
        Debug.Log("Destory bullet");
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
