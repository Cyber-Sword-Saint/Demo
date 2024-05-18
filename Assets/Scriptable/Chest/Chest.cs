using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chest", menuName = "Inventory/Chest")]
public class Chest : ScriptableObject
{
    [SerializeField]
    public List<Item> itemList = new List<Item>();

    [SerializeField]
    public List<int> itemNumList = new List<int>();

    public void AddItem(Item item)
    {
        if (!itemList.Contains(item))
        {
            itemList.Add(item);
            itemNumList.Add(1);
        }
        else
        {
            itemNumList[itemList.IndexOf(item)]++;
        }
        ChestUIController.RefreshItem();
    }

    public bool RemoveItem(Item item)
    {
        if (itemList.Contains(item))
        {
            int index = itemList.IndexOf(item);
            itemNumList[index]--;
            if (itemNumList[index] <= 0)
            {
                itemNumList.RemoveAt(index);
                itemList.Remove(item);
            }
            ChestUIController.RefreshItem();
            return true;
        }

        ChestUIController.RefreshItem();
        return false;
    }
}
