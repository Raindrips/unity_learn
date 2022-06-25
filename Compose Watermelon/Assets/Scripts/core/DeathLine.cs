using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLine : MonoBehaviour
{
    public GameObject deathUI;
    public TouchEvent touchEvent;
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Fruit") {
            
            if (deathUI != null) {
                deathUI.SetActive(true);
            }
           
            if (touchEvent != null) {
                touchEvent.SendMessage("GameOver");
            }
        }
    }
}
