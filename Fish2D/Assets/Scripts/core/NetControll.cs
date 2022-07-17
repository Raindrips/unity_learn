using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetControll : MonoBehaviour
{
    public Sprite[] netSprite;

    int netLevel;
    public void SetLevel(int level) {
        Debug.Log("Net:" + level);
        netLevel = level;
        if (level < netSprite.Length) {
            var sprite = GetComponent<SpriteRenderer>();
            sprite.sprite = netSprite[level];
        }
    }

    void DestorySelf() {
        Destroy(gameObject);
    }
}
