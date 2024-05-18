using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestSlot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;

    public void ItemOnClicked() 
    {
        ChestUIController.UpdateOnClick(slotItem);
    }
}
