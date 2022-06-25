using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomFruit : MonoBehaviour {
    public Sprite[] fruitSprites;
    public GameObject itemFruit;
   
    public static RandomFruit instance = null;

    private FruitsType nextType;

    public FruitsType NextType {
        get{
            return nextType;
        }
    }
    private void Awake() {
        instance = this;
    }

    void Start()
    {
        RandomType();
    }

    //×ª»»Í¼Æ¬
    public void RandomType() {
        int randomNum = Random.Range(0,(int)FruitsType.Orange);
        nextType = (FruitsType)randomNum;
        if (itemFruit) {
            var image=itemFruit.GetComponent<Image>();
            image.sprite = fruitSprites[randomNum];
        }
    }

}
