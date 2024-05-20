using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPCInteraction : MonoBehaviour
{
    public NPCProfile currProfile;
    public KeyCode interactionKey = KeyCode.E;
    [SerializeField]
    private string startNode = "Test";
    private bool playerInRange = false;
    private DialogueRunner dialogueRunner;


    private void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        Debug.Log($"DialogueRunnerFound: {dialogueRunner}");
        startNode = currProfile.dialougeNode;
        dialogueRunner.AddCommandHandler("start_divination_for_npc", StartDivinationForNPC);
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

    private void StartDivinationForNPC()
    {
        EventBus.Publish(new NPCDivinationEvent(currProfile));
    }
}