using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDivControl : MonoBehaviour
{
    public KeyCode key;
    public GameObject view;
    public GameObject NPCDivView;
    public SelectedDivItemsController divItemsController;
    // Start is called before the first frame update
    void Start()
    {
        closeSimpleDivPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            //Debug.Log("toggling simple div panel");
            if (view.activeSelf)
            {
                closeSimpleDivPanel();
            }

            else
            {
                openSimpleDivPanel();
            }
        }
    }

    // TODO IEnumerator animation/transisition effect
    void openSimpleDivPanel()
    {
        view.SetActive(true);
    }

    void closeSimpleDivPanel()
    {
        divItemsController.ResetSelection();
        view.SetActive(false);
    }

    /*void ShowNPCDivView(NPCDivinationEvent e)
    {
        NPCDivView.SetActive(true);
        view.SetActive(false);
        //Populate npcInfo 
        NPCDivView.GetComponent<CharInfoEntryController>().ShowCurrNPCInfo(e.currProfile);
    }*/
}
