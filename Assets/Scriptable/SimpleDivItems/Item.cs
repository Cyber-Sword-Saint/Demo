using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A SimpleDivObject parent class
/// </summary>
[CreateAssetMenu(fileName = "New Item", menuName = "Collectible/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    [TextArea]
    public string itemDescription;
    public Sprite overworldSprite;
    public Sprite icon;
    public string divResult;
    public List<Item> associatedDivItems;
    public int collectSFX;
    // public AudioClip collectSFX;
    /* possible properties
    public GameObject divVFX;
    public AudioClip divSFX;
    public GameObject collectVFX;
    */
    /// Add additional properties and methods
}

public enum ItemType
{
    PrimaryDivItem,
    SecondaryDivItem,
    CraftItem
    //TODO add more
}
