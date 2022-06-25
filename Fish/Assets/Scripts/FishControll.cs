using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControll : MonoBehaviour
{

    public float moveSpeed;
    public FishDate fishDate;

    public bool isAlive = true;

    private Vector2[] paths;

    private int nowPathIndex;

    public void Init(Vector2[] paths) {
        nowPathIndex = 0;
        this.paths = paths;
        transform.position = paths[0];
    }

    public void Hurt(int damage) {
        this.fishDate.HP -= damage;
        if (this.fishDate.HP <= 0) {
            this.isAlive = false;
        }
    }

    public void Die() {
        Animation animation = gameObject.GetComponent<Animation>();
        animation.Stop();
        animation.Play("fish_die");
    }

    public void DestorySelf() {
        Destroy(gameObject);
    }

    private void FixedUpdate() {
        if (paths!=null&&nowPathIndex<paths.Length) {
            
            MoveToPath(paths[nowPathIndex]);
        }    
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    //��Ŀ���ƶ�
    private void MoveToPath(Vector2 path) {
        
        // ��ȡ������������
        Vector2 position = transform.position;
        // ��Ļ����������������,��ȡ��������ķ���
        Vector3 direction = path - position;

        //�������
        float distance = Mathf.Abs(position.magnitude-path.magnitude);
        if (distance < moveSpeed*Time.deltaTime) {
            nowPathIndex++;
            return;
        }
        //transform.up = direction;
        transform.up = Vector3.Lerp(transform.up, direction, Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!isAlive) {
            return;
        }
        if (collision.gameObject.tag == "Bullet") {

        }
    }
}
