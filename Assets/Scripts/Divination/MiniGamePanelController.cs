using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePanelController : MonoBehaviour
{
    public KeyCode key;
    public GameObject view;
    private MiniGameController miniGameController; 
    
    // Start is called before the first frame update
    void Start()
    {
        miniGameController = view.GetComponent<MiniGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Debug.Log($"toggling {view.name} ");
            if (!view.activeSelf)
            {
                OpenPanel();
            }

            else
            {
                ClosePanel();
            }
        }
    }

    void OpenPanel()
    {
        view.SetActive(true);
    }

    void ClosePanel()
    {
        miniGameController.RestGame();
        view.SetActive(false);
    }
}
