using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public GameObject pinPrefab;

    public GameObject center;

    public Text textLevel;

    public LevelAssets levelAssets; 

    LevelData currentLevelData;

    void Start() {
        spawnDefaultBall();
        
    }

    // Update is called once per frame
    void Update() {

    }

    void Init() {

    }

    void LoadLevel(int index) {

    }

    void spawnDefaultBall() {
      
        //»ñÈ¡¿í¶È
        //float radius = center.GetComponent<RectTransform>().lossyScale.x/2;
        //Debug.Log(radius);
        float offset = 360 / 3;

        for (int i = 0; i < 3; i++) {
            center.transform.rotation=Quaternion.Euler(0,0,offset*i);
            GameObject pin = Instantiate(pinPrefab, new Vector3(320, 260, 0), Quaternion.Euler(0, 0, 0));
            pin.transform.SetParent(center.transform);
            pin.transform.localScale = Vector3.one;
           
        }

       
    }
}
