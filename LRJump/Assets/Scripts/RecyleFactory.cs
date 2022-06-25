using System.Collections;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 回收站
/// </summary>
public class RecyleFactory {

    public static RecyleFactory _recyleFactory;

    public static RecyleFactory Instance {
        get {
            if (_recyleFactory == null) {
                _recyleFactory = new RecyleFactory();
            }
            return _recyleFactory;
        }
    }

    public RecyleFactory() {
        this.linkList = new LinkedList<GameObject>();
    }

    /// <summary>
    /// 获取当前可用对象数量
    /// </summary>
    /// <returns>当前内存池大小</returns>
   public int Count() {
        return linkList.Count;
   }

    /// <summary>
    /// 清理回收站
    /// </summary>
    public void Clear() {
        foreach (GameObject item in linkList) {
            GameObject.Destroy(item);
        }
        linkList.Clear();
    }

    /// <summary>
    /// 将游戏对象放入回收站
    /// </summary>
    /// <param name="obj"></param>
    public void Put(GameObject obj) {
        if (obj == null) {
            return;
        }
        obj.transform.SetParent(null);
        obj.SetActive(false);
        linkList.AddLast(obj);
    }

    /// <summary>
    /// 从回收站取出游戏对象
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    public GameObject Get(GameObject prefab) {
        if (linkList.Count <= 0) {
            return GameObject.Instantiate(prefab);
        }
        GameObject obj = linkList.First.Value;
        linkList.RemoveFirst();
        obj.SetActive(true);
        return obj;
    }

    private LinkedList<GameObject> linkList;

}