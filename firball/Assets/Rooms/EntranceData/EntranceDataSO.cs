using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntranceData", menuName = "EntranceData")]
public class EntranceDataSO : ScriptableObject
{
    public GameObject nextRoom;
    public GameObject nextEntrance;
    
    public enum EntranceType
    {
        Left,
        Right,
        Up,
        Down,
    }

    public EntranceType entranceType;
}
