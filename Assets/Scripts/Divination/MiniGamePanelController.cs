using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class MiniGamePanelController : MonoBehaviour
{
    public KeyCode key;
    public GameObject view;
    private MiniGameController miniGameController;
    private DialogueRunner dialogueRunner;
    
    // Start is called before the first frame update
    void Start()
    {
        miniGameController = view.GetComponent<MiniGameController>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        //dialogueRunner.AddCommandHandler("run_mini_game", RunMiniGame);
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

    void RunMiniGame()
    {
        OpenPanel();
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
