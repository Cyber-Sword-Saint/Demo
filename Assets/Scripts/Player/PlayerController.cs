using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
	public BasicInventory inventory;
	public GameObject myInventoryUI;
	public KeyCode inventoryKey;

	public float moveSpeed;

	private Animator anim;
	private SpriteRenderer theSR;
	private Rigidbody2D theRB;
	public bool stopInput;

	// settings used for freeze playerInput
	public MiniGameController miniGameController;
	private DialogueRunner dialogueRunner;

	private void Awake()
	{
		instance = this;
	}

	// Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
		theSR = GetComponent<SpriteRenderer>();
		theRB = GetComponent<Rigidbody2D>();

		//    dialogueRunner
		dialogueRunner = FindObjectOfType<DialogueRunner>();
		
    }

    // Update is called once per frame
    void Update()
    {	
		if (!stopInput && !PauseMenu.instance.isPaused && !ChestController.instance.isOpen && !dialogueRunner.IsDialogueRunning && !miniGameController.isActiveAndEnabled)
		{  
			OpenInventory();

			if (!myInventoryUI.activeSelf)
			{
				float horizontalInput = Input.GetAxisRaw("Horizontal");
				float verticalInput = Input.GetAxisRaw("Vertical");

				bool moveHorizontal = true;
				bool moveUp = false;
				bool moveDown = false;

				if (horizontalInput < 0) {
					theSR.flipX = false;
				} else if (horizontalInput > 0) {
					theSR.flipX = true;
				} else {
					moveHorizontal = false;
				}

				if (verticalInput > 0) {
					moveUp = true;
					moveDown = false;
					if (horizontalInput == 0) {
						theSR.flipX = false;
					}
				} else if (verticalInput < 0) {
					moveUp = false;
					moveDown = true;
					if (horizontalInput == 0) {
						theSR.flipX = false;
					}
				} else {
					moveUp = false;
					moveDown = false;
				}

				Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
				Vector2 normalizedInput = inputVector.normalized;
				theRB.velocity = new Vector2(moveSpeed * normalizedInput.x, moveSpeed * normalizedInput.y);
				// No squash, good!

				anim.SetBool("moveHorizontal", moveHorizontal);
				anim.SetBool("moveUp", moveUp);
				anim.SetBool("moveDown", moveDown);

				theRB.freezeRotation = true;
			}
		} else {
			theRB.velocity = new Vector2(0, 0);
			anim.SetBool("moveHorizontal", false);
			anim.SetBool("moveUp", false);
			anim.SetBool("moveDown", false);
		}
    }

	void OpenInventory() {
		if (Input.GetKeyDown(inventoryKey))
		{
			myInventoryUI.SetActive(!myInventoryUI.activeSelf);
			InventoryController.RefreshItem();
		}
	}
}