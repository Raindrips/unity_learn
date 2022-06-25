using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGroup : MonoBehaviour
{

    public string text="";
    public GameObject textImage;
    public int offset = 24;
    private GameObject[] imageGroup;

    
    void Start()
    {
        imageGroup = new GameObject[3];
        for (int i = 0; i < 3; i++) {
            var prefab= Instantiate(textImage, transform.position, transform.rotation);
            prefab.transform.SetParent(transform);
            prefab.transform.localPosition = new Vector3(offset *i+1,0,0);
            prefab.transform.localScale = Vector3.one;
            imageGroup[i] = prefab;
        }
    }
    void Update()
    {
        for(int i = 0; i<3; i++) {
            var textImage = imageGroup[i].GetComponent<TextImage>();
            if (i < text.Length) {
                textImage.gameObject.SetActive(true);
                textImage.Number = text[i];
            }
            else {
                textImage.gameObject.SetActive(false);
            }
        }
    }
}
