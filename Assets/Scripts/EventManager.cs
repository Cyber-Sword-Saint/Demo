using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Event for picking up an item
/// </summary>
public class ItemPickUpEvent
{
    public string itemName;
    public Item item;
    public ItemPickUpEvent(string _name, Item _item)
    {
        itemName = _name;
        item = _item;
    }
}

public class SimpleDivItemSelectionEvent
{
    public Item item;
    public SimpleDivItemSelectionEvent(Item _item)
    {
        item = _item;
    }
}

/// <summary>
/// Event for divniation, including proficiency level increase and soul points being consumed
/// </summary>
public class DivinationEvent
{
    public float proficiencyIncrease;
    public float soulPointsDecrease;
    public DivinationEvent(float _increase,float _decrease) {
        proficiencyIncrease = _increase;
        soulPointsDecrease = _decrease;
    }
}

public class MiniGamePerfectEvent
{
    public MiniGamePerfectEvent() { }
}

public class MiniGameHitEvent
{
    public MiniGameHitEvent() { }
}

public class MiniGameFailEvent
{
    public MiniGameFailEvent() { }
}

public class StatChangeEvent
{
    public Stat stat;
    public StatChangeEvent(Stat _stat)
    {
        stat = _stat;
    }
}