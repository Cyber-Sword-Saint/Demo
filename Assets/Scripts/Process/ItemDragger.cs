using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragger : MonoBehaviour
{
    public Transform targetPosition;
    public GameObject powder;
    public Transform originalPosition;
    public bool isOverTarget = false;
    private bool isSelected;
    public float proximityThreshold = 1.0f;

    void Start()
    {
        // originalPosition = transform.position;
    }

    void Update()
    {
        if (isSelected)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        } else 
        {
            CheckIsOverTarget();
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isSelected = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSelected = false;
        }
    }

    private void CheckIsOverTarget()
    {
        if (Vector3.Distance(transform.position, targetPosition.position) < proximityThreshold)
        {
            Debug.Log("Into target!");
            Destroy(gameObject);
            if (powder)
            {
                powder.SetActive(true);
                powder.name = this.name;
                // TODO: add powder's item name
            } else {
                // pot list add this item
                PotController.instance.AddIngre(this.name);
            }
        } else
        {
            transform.position = originalPosition.position;
        }
    }
}
