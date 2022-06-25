using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{
 
    public float initSpeed = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameover
    }

    //向下加速
    public void boost()
    {
        var rigidBody = GetComponent<Rigidbody>();
        if (rigidBody)
        {
            rigidBody.velocity = new Vector3(0, -initSpeed, 0);
        }
        
    }

    void bouce()
    {
        var rigidBody = GetComponent<Rigidbody>();
        if (rigidBody)
        {
            rigidBody.velocity=new Vector3(0, this.initSpeed, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            bouce();
        }
        // emit 
    }
}
