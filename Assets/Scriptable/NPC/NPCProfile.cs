using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// A NPC profile parent class
/// </summary>
[CreateAssetMenu(fileName = "New NPC Profile", menuName = "NPC/NPCProfile")]
public class NPCProfile : ScriptableObject
{
    [Header("NPC Info")]
    public string npcName;
    public Color sigilColor;
    public NPCType npcType;
    public string description;
    public Sprite npcPortrait;
    [Header("NPC Dialogue Settings")]
    [Tooltip("A list of TextAsset representing the NPC dialogue sequence")]
    public string dialougeNode;
    [Header("NPC Divnination Settings")]
    public List<Item> itemsToUseForDivination;
    public List<NPCInfo> npcInfoList;
}

public enum NPCType
{
    Default,
    Important
}
