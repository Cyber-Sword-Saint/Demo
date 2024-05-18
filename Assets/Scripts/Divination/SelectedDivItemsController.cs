using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedDivItemsController : MonoBehaviour
{
    Subscription<SimpleDivItemSelectionEvent> simple_div_item_selection_event;
    public GameObject selectedDivItemIconPrefab;
    public GameObject secondaryDivView;
    public TextMeshProUGUI divResult;
    public BasicInventory playerInventory;

    [Header("Private Variables")]
    [SerializeField]
    private Item primary_item;
    [SerializeField]
    private GameObject primary_icon;
    [SerializeField]
    private Item secondary_item;
    [SerializeField]
    private GameObject secondary_icon;
    [SerializeField]
    private Button[] secondary_buttons;
    
    // Start is called before the first frame update
    void Start()
    {
        simple_div_item_selection_event = EventBus.Subscribe<SimpleDivItemSelectionEvent>(OnItemSelection);
        secondary_buttons = secondaryDivView.GetComponentsInChildren<Button>();
    }

    private void Update()
    {
        if(primary_item == null && secondary_item == null)
        {
            this.GetComponent<Button>().interactable = false;
        }

        else
        {
            this.GetComponent<Button>().interactable = true;
        }
    }

    void OnItemSelection(SimpleDivItemSelectionEvent e)
    {
        //TODO refacotr
        // two functions
        // create icon
        // remove icon
        foreach(Button secondary_button in secondary_buttons)
        {
            HideSecondaryButtons(secondary_button);
        }

        Debug.Log($"{e.item.itemName} of {e.item.itemType} selected for dinivation");
        if (e.item.itemType == ItemType.PrimaryDivItem)
        {
            primary_item = e.item;
            if (this.transform.childCount == 0) // if primary div item selected for the first time -> spawn in primary icon
            {
                selectedDivItemIconPrefab.GetComponent<Image>().sprite = e.item.icon;
                primary_icon = Instantiate(selectedDivItemIconPrefab, this.transform);
                primary_icon.transform.parent = this.transform;
            }

            else if (this.transform.childCount == 1)
            {
                    primary_icon.GetComponent<Image>().sprite = e.item.icon;
            }

            if (!secondaryDivView.activeSelf)
            {
                secondaryDivView.SetActive(true);
            }

            // get associated secondary div items
            if (primary_item.associatedDivItems.Count != 0)
            {
                int index = 0;
                foreach (Item associated_item in primary_item.associatedDivItems)
                {
                    Button curr_button = secondary_buttons[index];
                    ShowSecondaryButton(curr_button, associated_item);
                    index++;
                }
            }
        }

      
        else if(e.item.itemType == ItemType.SecondaryDivItem)
        {
            secondary_item = e.item;
            if(this.transform.childCount == 1)   // if secondary div item selected for the first time -> spawn in secondary icon 
            {
                selectedDivItemIconPrefab.GetComponent<Image>().sprite = e.item.icon;
                secondary_icon = Instantiate(selectedDivItemIconPrefab, this.transform);
                secondary_icon.transform.parent = this.transform;
            }

            else if(this.transform.childCount == 2)
            {
                secondary_icon.GetComponent<Image>().sprite = e.item.icon;
            }
        }
    }

    public void ShowSecondaryButton(Button button,Item associated_item )
    {
        Image curr_image = button.GetComponent<Image>();
  
        TextMeshProUGUI quantity_text = button.GetComponentInChildren<TextMeshProUGUI>();
        quantity_text.enabled = true;
        curr_image.sprite = associated_item.icon;
        button.GetComponent<SimpleDivUI>().currItem = associated_item;
        Debug.Log($"associated item:{associated_item}, curr item:{button.GetComponent<SimpleDivUI>().currItem}");
        curr_image.enabled = true;
        button.enabled = true;
    }

    public void HideSecondaryButtons(Button button)
    {
        Image curr_image = button.GetComponent<Image>();
        TextMeshProUGUI quantity_text = button.GetComponentInChildren<TextMeshProUGUI>();
        quantity_text.enabled = false;
        curr_image.enabled = false;
        button.enabled = false;
    }

    public void ResetSelection()
    {
        primary_item = null;
        secondary_item = null;
        if (primary_icon != null)
        {
            Destroy(primary_icon);
        }

        if (secondary_icon != null)
        {
            Destroy(secondary_icon);
        }

        foreach (Button button in secondary_buttons)
        {
            HideSecondaryButtons(button);
        }
    }


    public void StartsDivination()
    {
        if(primary_item != null)
        {
            playerInventory.UseItem(primary_item);
            DestroyImmediate(primary_icon, true);
        }

        if(secondary_item != null)
        {
            playerInventory.UseItem(secondary_item);
            DestroyImmediate(secondary_icon, true);
        }

        if(primary_item != null && secondary_item == null)
        {
            Debug.Log($"Simple div with {primary_item} selected");
            divResult.text = primary_item.divResult;
        }

        else
        {
            Debug.Log($"Simple div with {primary_item} and {secondary_item} selected");
            divResult.text = " This is a temp placeholder text";
        }
       
       
        StartCoroutine(eraseText(3f));
        primary_item = null;
        secondary_item = null;
        EventBus.Publish(new DivinationEvent(10,5));
    }

    IEnumerator eraseText(float duration)
    {
        yield return new WaitForSeconds(duration);
        divResult.text = "";
    }
}
