using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "Level/Date")]
public class LevelAssets : ScriptableObject {
    public LevelData[] levelDatas;

    public LevelData GetLevel(int index) {
        if (index >= 0 && index < levelDatas.Length) {
            return levelDatas[index];
        }
        return new LevelData();
    }

}