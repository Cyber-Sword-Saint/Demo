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
    private SimpleDivControl div_control;

    public void Start()
    {
        curr_button = GetComponent<Button>();
        quantity_ui = GetComponentInChildren<TextMeshProUGUI>();
        div_control = FindObjectOfType<SimpleDivControl>();

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
            quantity = inventory.itemNumList[inventory.itemList.IndexOf(currItem)];
            quantity_ui.text = $"{quantity}";
    
        }

        // if item found in list
        else
        {
            quantity = 0;
            quantity_ui.text = $"{quantity}";
            hasItem = false;
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
        if (inventory.UseItem(currItem))
        {
            resultText.text = currItem.divResult;
        }
        StopAllCoroutines();
        StartCoroutine(ClearTextAfter(5f));
    }

    public IEnumerator ClearTextAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        resultText.text = "";
    }
}


