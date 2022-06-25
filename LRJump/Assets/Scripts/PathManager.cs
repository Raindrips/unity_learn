using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public GameObject pathPrefab;       //路径预制件对象
    public float startY;                //y轴起点位置


    private float intervalX;            
    private float intervalY;            //y轴间隔
    public float IntervalY {
        get => intervalY;
    }

    private float offsetX;              //x偏移
    private float maxOffsetX;           //

    private Transform firstPath;         //第一个路径
    public Transform FirstPath {
        get => firstPath;
    }
    public Transform Last {
        get => lastPath;
    }
    private Transform lastPath;         //最后一个路径

    private int count=0;

    private void Awake() {
        var rect = pathPrefab.GetComponent<RectTransform>();
        intervalX = rect.rect.width * 0.5f;
        intervalY = rect.rect.height *0.5f;
        Debug.Log("x:" + intervalX + " y:" + intervalY);

        offsetX = 0;
        maxOffsetX = 3;
    }

    // 创建路径的数量
    public void CreatePath(float count) {
        for (int i = 0; i < count; i++) {
            InitPath();
        }
    }

    //从回收站中拿到一个节点
    public GameObject GetPath() {
        RecyleFactory recyle = RecyleFactory.Instance;
        GameObject path = recyle.Get(pathPrefab);
        path.transform.SetParent(transform);
        return path;
    }


    // 初始化路径
    public void InitPath() {
        GameObject path = GetPath();
        var pathControl = path.GetComponent<PathController>();
        int random = GetRandomSign();
        float temp = offsetX + random;

        //如果越界就返回
        if (temp>maxOffsetX||temp<-maxOffsetX) {
            offsetX -= random;
        }
        else {
            offsetX += random;
        }

 
        float y = startY;
        if (lastPath) {
            y = lastPath.localPosition.y+intervalY;
            lastPath.GetComponent<PathController>().next=pathControl;
        }

        //设置坐标
        Vector3 position = new Vector3();
        position.y = y;
        position.x = offsetX * intervalX;
        path.transform.localPosition = position;
        path.transform.SetAsFirstSibling();

        if (firstPath==null) {
            firstPath = path.transform;
        }
        lastPath = path.transform;

        count++;
        pathControl.SetNumber(count);
    }

    //随机左右方向
    int GetRandomSign()
    {
        return (int)Mathf.Sign(Random.Range(-1.0f, 1.0f));
    }
}
