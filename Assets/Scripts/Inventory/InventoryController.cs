using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryController : MonoBehaviour
{
    static InventoryController instance;
    public BasicInventory inventory;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInformation;

    void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "test";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        Debug.Log("UpdateItemInfo");
        Debug.Log(itemDescription);
        instance.itemInformation.text = itemDescription;
        Debug.Log(instance.itemInformation.text);
    }

    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.icon;
        // newItem.slotNum.text = instance.inventory.InventoryDict[item.itemName].ToString();
        newItem.slotNum.text = instance.inventory.itemNumList[instance.inventory.itemList.IndexOf(item)].ToString();
    }

    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
            {
                break;
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < instance.inventory.itemList.Count; i++)
        {
            CreateNewItem(instance.inventory.itemList[i]);
        }
    }
}
