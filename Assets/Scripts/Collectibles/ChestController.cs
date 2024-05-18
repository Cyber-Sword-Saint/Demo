using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E;
    private bool isInRange;
    public bool isOpen;

    public GameObject chestInventory;
    public GameObject playerInventory;
    public Chest chest;
    public static ChestController instance;

	public void Awake()
	{
		instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
        chestInventory.SetActive(false);
        playerInventory.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.instance.isPaused) {
			OpenChest();
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

    private void OpenChest()
    {
        if ((Input.GetKeyDown(pickupKey) || Input.GetButtonDown("PickUp")) && isInRange)
        {
            isOpen = !isOpen; 

            if (isOpen)
            {
                PlayerController.instance.myInventoryUI.SetActive(false);
                chestInventory.SetActive(true);
                playerInventory.SetActive(true);

                InventoryController.isChesting = true;
            } else {
                chestInventory.SetActive(false);
                playerInventory.SetActive(false);
                
                InventoryController.isChesting = false;

            }
        }

        
    }
}
