using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextImage : MonoBehaviour {

    //获取图片纹理图
    public Texture2D texture2D;

    //图片组件
    private Image image;        

    private char number = '0';

    private void Awake() {
        image = GetComponent<Image>();
    }

    public void Start() {
        cut(number-'0');
    }

    public char Number {
        get {
            return number;
        }
        set {
            this.number = value;
            cut(number - '0');
        }
    }

    //裁剪图片
    void cut(int offset) {

        Sprite sprite = Sprite.Create(texture2D,new Rect(offset*24, 0,24,36),new Vector2(0.0f,0.0f));
        image.sprite = sprite;
    }

}