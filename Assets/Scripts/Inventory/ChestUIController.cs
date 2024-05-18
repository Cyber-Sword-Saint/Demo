using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUIController : MonoBehaviour
{
    static ChestUIController instance;
    public BasicInventory playerInventory;
    public Chest inventory;
    public GameObject slotGrid;
    public ChestSlot slotPrefab;
    
    void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {

        RefreshItem();       
    }

    public static void UpdateOnClick(Item item)
    {
        instance.inventory.RemoveItem(item);
        instance.playerInventory.AddItem(item);
    }

    public static void CreateNewItem(Item item)
    {
        ChestSlot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.icon;
        // newItem.slotNum.text = instance.inventory.InventoryDict[item.itemName].ToString();
        newItem.slotNum.text = instance.inventory.itemNumList[instance.inventory.itemList.IndexOf(item)].ToString();
        
        Debug.Log(item.itemName + ": " + instance.inventory.itemNumList[instance.inventory.itemList.IndexOf(item)].ToString());
    }

    public static void RefreshItem()
    {
        Debug.Log("Refresh chest");

        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount <= 0)
            {
                break;
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < instance.inventory.itemList.Count; i++)
        {
            CreateNewItem(instance.inventory.itemList[i]);
            
        }

        Debug.Log("Refresh chest done");


    }
}
