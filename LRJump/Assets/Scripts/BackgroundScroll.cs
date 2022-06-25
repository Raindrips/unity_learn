using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {
    public Transform bg1;
    public Transform bg2;

    public float height;

    private void Awake() {
        if (bg1 == null || bg2 == null) {
            enabled = false;
            Debug.LogError("bg1 or bg2 is null");
        }  
    }

    private void OnEnable() {
        var eventManager = EventManager.Instance;
        eventManager.On("Reset", this.Reset);
    }

    private void OnDisable() {
        var eventManager = EventManager.Instance;
        eventManager.Off("Reset", this.Reset);
    }

    public void Reset() {
      
        if (bg1==null || bg2==null) {
            return;
        }
        Vector3 v1 = bg1.position;
        Vector3 v2 = bg2.position;

        if (v1.y > v2.y) {
            v2.y = v1.y + height;
            bg2.position = v2;
        }
        else if (v2.y > v1.y) {
            v1.y = v2.y + height;
            bg1.position = v1;
        }

        Debug.Log("Move_Down");
    }
}
