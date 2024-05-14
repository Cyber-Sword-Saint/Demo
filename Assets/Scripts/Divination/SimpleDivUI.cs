using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SimpleDivUI : MonoBehaviour
{
    [Header("Public variables (Edit)")]
    public Item currItem;
    public BasicInventory inventory;
    public TextMeshProUGUI resultText;
    public SimpleDivControl divControl;
    public bool itemSelected;

    [Header("Private variables (Do Not Edit)")]
    [SerializeField]
    private int quantity;
    [SerializeField]
    private bool hasItem = false;
    [SerializeField]
    private Button curr_button;
    [SerializeField]
    private TextMeshProUGUI quantity_ui;
    [SerializeField]
    //private Inventory inventory;

    public void Start()
    {
        curr_button = GetComponent<Button>();
        quantity_ui = GetComponentInChildren<TextMeshProUGUI>();
        //inventory = FindObjectOfType<Inventory>();

    }

    public void Update()
    {

        if (inventory.itemList.Contains(currItem))
        {

            if (quantity > 0)
            {
                hasItem = true;
            }
            else
            {
                hasItem = false;
            }
            quantity = inventory.InventoryDict[currItem.itemName];
            quantity_ui.text = $"{quantity}";
    
        }

        curr_button.interactable = hasItem;
      
    }

    public void SelectItem()
    {
        // publish item selection event
        EventBus.Publish(new SimpleDivItemSelectionEvent(currItem));
        //itemSelected = true;
    }

    public void UseItem()
    {
        
        inventory.UseItem(currItem.itemName);
        resultText.text = currItem.divResult;
        StopAllCoroutines();
        StartCoroutine(ClearTextAfter(5f));
    }

    public IEnumerator ClearTextAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        resultText.text = "";
    }
}


