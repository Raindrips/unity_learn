﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

    private SpriteRenderer sr;
    public GameObject explosionPrefab;
    public AudioClip dieAudio;

    public Sprite BrokenSprite;

    // Use this for initialization
    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }
    public void Die() {
        sr.sprite = BrokenSprite;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(dieAudio, transform.position);
        //
        GameObject playerManage = GameObject.Find("PlayerManager");
        playerManage.GetComponent<PlayerManager>().isDefeat=true;
        
    }
}
