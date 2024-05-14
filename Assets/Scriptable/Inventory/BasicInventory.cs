using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Basic Inventory")]
public class BasicInventory : ScriptableObject
{
    [SerializeField]
    public List<Item> itemList = new List<Item>();

    [SerializeField]
    public Dictionary<string, int> InventoryDict = new Dictionary<string,int>();

    public void AddItem(Item item)
    {
        if (!itemList.Contains(item) && !InventoryDict.ContainsKey(item.itemName))
        {
            itemList.Add(item);
            InventoryDict.Add(item.itemName, 1);
            // InventoryController.CreateNewItem(item);
        }
        else
        {
            InventoryDict[item.itemName] += 1;
        }

        InventoryController.RefreshItem();

        Debug.Log($"{item.itemName}:{InventoryDict[item.itemName]}");
    }
    
    public void UseItem(string itemName)
    {
        //TODO check cases, item enum to decided what happens when item is useds
        if (InventoryDict.ContainsKey(itemName))
        {
            InventoryDict[itemName] -= 1;
            if (InventoryDict[itemName] == 0)
            {
                //TODO remove item from inventory list (ui hook)
            }
        }
    }

}


