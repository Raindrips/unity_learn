using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ˮ��������
public class PipeSpawner : MonoBehaviour
{

    public GameObject pipePrefab;
    private void Start() {
        //GameStart();
    }
    public void GameStart() {
        InvokeRepeating("SpawnPipe",1,1);
    }

    public void Stop() {
        CancelInvoke("SpawnPipe");
    }

    //����ˮ��
    void SpawnPipe() {
        var pipe = Instantiate(pipePrefab,transform.position,transform.rotation);
        pipe.transform.SetParent(transform);
        pipe.transform.localScale = Vector3.one;
        var pipeController = GetComponent<PipeController>();
        if (pipeController) {
            pipeController.init();
        }
    }
}
