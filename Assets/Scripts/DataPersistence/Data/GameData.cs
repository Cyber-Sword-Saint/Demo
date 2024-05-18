using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class GameData
{
    public int dayCount;
    public int weatherType;

    // TODO: save the inventory

    // public int divineCount;
    public GameData()
    {
        dayCount = 1;
        weatherType = 0;
        Debug.Log("New data generated");

    }
}
