using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIEvent : MonoBehaviour
{
    public UnityEvent unityEvent;

    private void Start() {
        if (unityEvent!=null) {
            //通知所有外部的函数
            unityEvent.Invoke();
        }
    }

    public void OnStart() {
        SceneManager.LoadScene(1);
    }
}
