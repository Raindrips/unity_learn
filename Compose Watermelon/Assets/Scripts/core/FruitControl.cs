using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FruitControl : MonoBehaviour {

    public Sprite[] fruitSprite;
    public Sprite boom;
    public FruitsType fruitType;

    void Start() {
        RandomFruit randomFruit = RandomFruit.instance;
        if (randomFruit==null) {
            return;
        }
        FruitsType randomType= randomFruit.NextType;
        randomFruit.RandomType();
        ChangeFruit(randomType);
    }

    public void ChangeFruit(FruitsType fruit) {

        //修改节点属性
        fruit = CheckFruit(fruit);
        fruitType = fruit;
        gameObject.name = fruit.ToString();

        //修改精灵图片
        var image = GetComponent<Image>();
        int id = (int)fruit;
        Debug.Log("fruit:"+ id);
        image.sprite = fruitSprite[id];
        image.SetNativeSize();
       
        //修改物理属性大小
        var collider = GetComponent<CircleCollider2D>();
        var rect = image.GetComponent<RectTransform>();
        collider.radius = rect.rect.width/2;
        
    }
    
    //检查参数是否合法
    FruitsType CheckFruit(FruitsType fruit) {
        if (fruit < 0) {
            fruit = 0;
        }
        if(fruit> FruitsType.Watermelon) {
            fruit = FruitsType.Watermelon;
        }

        return fruit;
    }

    //发生碰撞
    //private void OnCollisionEnter2D(Collision2D collision) {
    private void OnCollisionEnter2D(Collision2D collision) {
        string otherTag = collision.collider.tag;
        //Debug.Log(otherTag);
        if (otherTag != "Fruit") {
            return;
        }
        FruitControl otherType = collision.gameObject.GetComponent<FruitControl>();
        if (otherType.fruitType==fruitType) { 
            Debug.Log("true fruit other:"+ otherType.fruitType+"self:"+fruitType);
            if (transform.position.y < otherType.transform.position.y) {
                Destroy(otherType.gameObject);
                FruitMerge();
            }
        }
    }

    //水果合并
    void FruitMerge() {
        var image = GetComponent<Image>();
        image.sprite = boom;
        var animation = gameObject.GetComponent<Animation>();
        animation.Play();
        Invoke("CallBack", 0.25f);
    }

    public void CallBack() {
        var animation = gameObject.GetComponent<Animation>();
        animation.Stop();
        FruitsType newType = fruitType + 1;
        ChangeFruit(newType);
    }

}

