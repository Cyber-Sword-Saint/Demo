using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
	public GameObject myInventory;
	public KeyCode inventoryKey;

	public float moveSpeed;

	private Animator anim;
	private SpriteRenderer theSR;
	private Rigidbody2D theRB;
	public bool stopInput;

	// TODO: logic refactor for pausing the game
	private bool pauseMenuActive = false;
	private bool chestIsOpent = false;

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
    }

    // Update is called once per frame
    void Update()
    {
		if (!stopInput && !PauseMenu.instance.isPaused && !ChestController.instance.isOpen) {  
			OpenInventory();
			if (!myInventory.activeSelf)
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
			myInventory.SetActive(!myInventory.activeSelf);
		}
	}
}