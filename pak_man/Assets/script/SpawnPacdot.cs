using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPacdot : MonoBehaviour {

    public GameObject prefabObject;
    public GameObject mazeComplete;

    public void Awake() {
        foreach(Transform trans in mazeComplete.transform) {
            var go=Instantiate(prefabObject, trans.position, trans.rotation);
            go.transform.parent = transform;
            if (trans.gameObject.tag=="SuperPickdot") {
                go.transform.localScale *= 3;
                go.SendMessage("setSuper");
            }
        }
    }

    void Update() {

    }
}
