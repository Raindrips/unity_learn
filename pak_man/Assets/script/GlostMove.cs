using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlostMove : MonoBehaviour {
    public GameObject path;
    public float speed = 0.2f;
    private List<Vector3> wayPoints = new List<Vector3>();
    private int index = 0;

    void Start() {
        foreach(Transform t in path.transform) {
            wayPoints.Add(t.position);
        }
    }

    void Update() {
        if (transform.position != this.wayPoints[index]) {
            Vector2 temp = Vector2.MoveTowards(transform.position, wayPoints[index], speed*Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(temp);
        }
        else {
            index = (index + 1) % wayPoints.Count; 
        }
        Vector2 dir = wayPoints[index] + transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y); 

    }
    private void FixedUpdate() {


    }

}
