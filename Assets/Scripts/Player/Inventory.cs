using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //TODO string => item dictionary
    public static Inventory instance;
    Subscription <ItemPickUpEvent> item_pick_up_event_subscription;
    public List<Item> itemList = new List<Item>();
    public Dictionary<string, int> InventoryDict = new Dictionary<string, int>();
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        item_pick_up_event_subscription = EventBus.Subscribe<ItemPickUpEvent>(OnPickUp);
    }

    /// <summary>
    /// pickupevent call back, updates player Inventory
    /// </summary>
    /// <param name="e"></param>
    void OnPickUp(ItemPickUpEvent e)
    {
        if (!itemList.Contains(e.item))
        {
            itemList.Add(e.item);
            InventoryDict[e.itemName] = 1;
            // InventoryController.CreateNewItem(e.item);
        }
        else
        {
            InventoryDict[e.itemName] += 1;
        }
        Debug.Log($"{e.itemName}: {InventoryDict[e.itemName]}");
    }

    // TODO maybe use item should be a public function inside the item scriptable
    public bool UseItem(string itemName)
    {
        //TODO check cases, item enum to decided what happens when item is useds
        if (InventoryDict.ContainsKey(itemName))
        {
            if (InventoryDict[itemName] > 0)
            {
                InventoryDict[itemName] -= 1;
                if (InventoryDict[itemName] == 0)
                {
                    //TODO remove item from inventory list (ui hook)
                }
                return true;
            }
        }
        return false;
    }

}