using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PathController : MonoBehaviour {
    public Text text;

    private PathController _prev;        //上一个对象
    private PathController _next;        //下一个节点

    private float _offset;               // 偏移范围

    //公有访问器
    public PathController next {
        set{
            _next = value;
            if (value) {
                value._prev = this;
            }
        }
        get => _next;
    }

    public PathController prev {
        set {
            this._prev = value;
            if (value) {
                value.next = this;
            }
        }
        get => _prev;
    }

    public float offset {
        get => _offset;
    }

    public void SetNumber(int number) {
        if (text && text.IsActive()) {
            text.text = number.ToString();
        }
    }

    //下降
    public void Down(float y) {
        float moveY = transform.localPosition.y + y;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveY(moveY,0.4f));
        sequence.AppendCallback(recycling);
    }

    //回收
    void recycling() {
        RecyleFactory recyle = RecyleFactory.Instance;
        recyle.Put(this.gameObject);
    }

}
