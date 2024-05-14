using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUIController : MonoBehaviour
{
    static ChestUIController instance;
    public BasicInventory chestInventory;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public List<Item> itemInChest = new List<Item>();
    
    void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        foreach (var item in itemInChest)
        {
            CreateNewItem(item);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.icon;
    }
}
