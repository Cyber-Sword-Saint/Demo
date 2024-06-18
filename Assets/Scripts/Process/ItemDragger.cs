using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragger : MonoBehaviour
{
    public Transform mortarPosition;
    public GameObject readySymbol;
    public Vector3 originalPosition;
    public bool isOverMortar = false;
    private bool isSelected;
    public float proximityThreshold = 1.0f;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        Debug.Log(Input.mousePosition.x + ", " + Input.mousePosition.y + ", " + Input.mousePosition.z);
        
        if (isSelected)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        } else 
        {
            CheckIsOverMortar();
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

    private void CheckIsOverMortar()
    {
        if (Vector3.Distance(transform.position, mortarPosition.position) < proximityThreshold)
        {
            Debug.Log("Into mortar!");
            Destroy(gameObject);
            readySymbol.SetActive(true);

        }
    }


    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     originalPosition = transform.position;
    //     Debug.Log("Begin Drag");
    // }


    // public void OnDrag(PointerEventData eventData)
    // {
    //     Vector3 screenPoint = Input.mousePosition;
    //     screenPoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
    //     transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    // }

    // public void OnEndDrag(PointerEventData eventData)
    // {
  
    //     if (isOverMortar)
    //     {
    //         Destroy(gameObject);
    //         Debug.Log("get item in mortar");
    //     }
    //     else
    //     {
    //         transform.position = originalPosition;
    //     }
    // }

    // void OnTriggerEnter(Collider other)
    // {
    //     Debug.Log(other.transform);
    //     if (other.transform == mortarPosition)
    //     {
    //         isOverMortar = true;
    //     }
    // }

    // void OnTriggerExit(Collider other)
    // {
    //     if (other.transform == mortarPosition)
    //     {
    //         isOverMortar = false;
    //     }
    // }
}
