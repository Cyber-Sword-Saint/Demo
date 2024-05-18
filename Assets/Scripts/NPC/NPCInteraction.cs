using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPCInteraction : MonoBehaviour
{
    public string startNode = "Test";
    private bool playerInRange = false;
    private DialogueRunner dialogueRunner;
    public KeyCode interactionKey = KeyCode.E;

    private void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        Debug.Log($"DialogueRunnerFound: {dialogueRunner}");
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            StartDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void StartDialogue()
    {
        dialogueRunner.StartDialogue(startNode);
    }
}