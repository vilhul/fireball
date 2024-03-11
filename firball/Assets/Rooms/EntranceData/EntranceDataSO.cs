using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

[CreateAssetMenu(fileName = "EntranceData", menuName = "EntranceData")]
public class EntranceDataSO : ScriptableObject
{
    public SceneAsset nextRoom;
    public SceneAsset thisRoom;
    public GameObject nextEntrance;
}
