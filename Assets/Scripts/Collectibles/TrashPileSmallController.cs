using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPileSmallController : MonoBehaviour
{
    private bool isCollected;
    private bool isInRange;

    public Item currItem;
    public BasicInventory inventory;
    public GameObject[] prefabsToSpawn = new GameObject[4];

    public KeyCode pickupKey = KeyCode.E;
    public GameObject pickupEffect;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(pickupKey) || Input.GetButtonDown("PickUp")) && !isCollected && isInRange)
        {

            isCollected = true;

            System.Random random = new System.Random();
            int itemIndex = random.Next(0, 4); // generate int from [minValue, maxValue]
            Instantiate(prefabsToSpawn[itemIndex], transform.position, Quaternion.identity);
            Destroy(gameObject);
        
            
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
        
}
