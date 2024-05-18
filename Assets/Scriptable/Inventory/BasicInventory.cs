using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Basic Inventory")]
public class BasicInventory : ScriptableObject
{
    [SerializeField]
    public List<Item> itemList = new List<Item>();

    [SerializeField]
    public Dictionary<string, int> InventoryDict = new Dictionary<string,int>();

    [SerializeField]
    public List<int> itemNumList = new List<int>();

    public bool isChest;

    public void Clear()
    {
        itemList = new List<Item>();
        InventoryDict = new Dictionary<string,int>();
        itemNumList = new List<int>();
    }
    
    public void AddItem(Item item)
    {
        Debug.Log("Add: " + item.itemName);

        if (!itemList.Contains(item))
        {
            itemList.Add(item);
            itemNumList.Add(1);
        } else {
            itemNumList[itemList.IndexOf(item)]++;
        }

        
        // if (InventoryDict.ContainsKey(item.itemName))
        // {
        //     InventoryDict[item.itemName] += 1;
        //     itemNumList[itemList.IndexOf(item)]++;
        // }
        // else
        // {
        //     InventoryDict.Add(item.itemName, 1);
        // }

        InventoryController.RefreshItem();

        Debug.Log($"{item.itemName}:{itemNumList[itemList.IndexOf(item)]}");
    }
    
    public bool UseItem(Item item)
    {
        bool ret = false;

        //TODO check cases, item enum to decided what happens when item is useds
        if (itemList.Contains(item))
        {
            Debug.Log("Use: " + item.itemName);

            itemNumList[itemList.IndexOf(item)]--;
            if (itemNumList[itemList.IndexOf(item)] == 0)
            {  
                itemNumList.RemoveAt(itemList.IndexOf(item));
                itemList.Remove(item);
            }

            ret = true;
        }

        InventoryController.RefreshItem();

        return ret;
    }
}


