using UnityEditor;
using UnityEngine;

[System.Serializable]
public struct LevelData {
    public float speed;             //速度
    public float defaultNumber;     //默认数量
    public float pinNumber;         //针的数量
    public bool isClockWise;        // 是否是顺时针
}