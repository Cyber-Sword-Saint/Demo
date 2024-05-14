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
    public BasicInventory inventory;
    public static ChestController instance;

	public void Awake()
	{
		instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.instance.isPaused) {
            
			OpenChest();
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

    private void OpenChest()
    {
        if ((Input.GetKeyDown(pickupKey) || Input.GetButtonDown("PickUp")) && isInRange)
        {
            isOpen = !isOpen; 
            chestInventory.SetActive(false);
            playerInventory.SetActive(false);
        }

        if (isOpen)
        {
            PlayerController.instance.myInventory.SetActive(false);
            chestInventory.SetActive(true);
            playerInventory.SetActive(true);
        } else {
            chestInventory.SetActive(false);
            playerInventory.SetActive(false);
        }
    }
}
