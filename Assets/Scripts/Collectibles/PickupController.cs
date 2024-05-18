using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PickupController : MonoBehaviour
{
    private bool isCollected;
    private bool isInRange;
    public Item currItem;
    public KeyCode pickupKey = KeyCode.E;
    // public BasicInventory inventory;
    public GameObject pickupEffect;



    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if ((Input.GetKeyDown(pickupKey) || Input.GetButtonDown("PickUp")) && !isCollected && isInRange)
        {
            isCollected = true;
            
            Destroy(gameObject);

            //Instantiate(pickupEffect, transform.position, transform.rotation);

            if (currItem != null)
            {
                EventBus.Publish(new ItemPickUpEvent(currItem.itemName, currItem));
                
                //TODO: suggetion: it might help if we put pickup SFX & VFX 
                //      as public variables of the Item scriptable class 

                // Another inventory logic
                AddNewItem();

                AudioManager.instance.PlaySFX(currItem.collectSFX);
            }
            Debug.Log("Item collected!");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
    }

    private void AddNewItem() 
    {
        PlayerController.instance.inventory.AddItem(currItem);
    }
}

