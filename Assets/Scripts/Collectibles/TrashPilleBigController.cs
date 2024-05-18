using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrashPilleBigController : MonoBehaviour
{
    private bool isCollected;
    private bool isInRange;
    private int itemAmount;

    public Item currItem;
    public GameObject[] prefabsToSpawn = new GameObject[3];

    public KeyCode pickupKey = KeyCode.E;
    public GameObject pickupEffect;

    private float throwHeight = 1f;
    private float throwDuration = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        int minValue = 2;
        int maxValue = 6;

        itemAmount = random.Next(minValue, maxValue + 1); // generate int from [minValue, maxValue]
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(pickupKey) || Input.GetButtonDown("PickUp")) && !isCollected && isInRange && itemAmount > 0)
        {
            System.Random random = new System.Random();
            int itemIndex = random.Next(0, 3); // generate int from [minValue, maxValue]
            GameObject spawnedItem = Instantiate(prefabsToSpawn[itemIndex], transform.position + new Vector3(itemAmount * 0.2f, -0.3f, 0f), Quaternion.identity);

            ThrowItem(spawnedItem);

            itemAmount--;

            if (itemAmount == 0) {
                isCollected = true;
                // Destroy(gameObject);
            }
            
            //Instantiate(pickupEffect, transform.position, transform.rotation);
            if (currItem != null)
            {
                EventBus.Publish(new ItemPickUpEvent(currItem.itemName, currItem));
            }
            //TODO: suggetion: it might help if we put pickup SFX & VFX as public variables of the Item scriptable class 
            AudioManager.instance.PlaySFX(0);
            Debug.Log("Item collected!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
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

    public void ThrowItem(GameObject spawnedItem)
    {
        spawnedItem.transform.DOJump(spawnedItem.transform.position, throwHeight, 1, throwDuration)
        .SetEase(Ease.OutQuint)
        .OnComplete(() =>
        {

        });
    }
        
}

