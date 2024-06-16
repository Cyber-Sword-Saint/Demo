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
    public List<string> DivinationResultNodes;
    /* 0:perfet 
     * 1:exerllent 
     * 2:fair 
     * 3:failure*/
    [SerializeField] private NPCController npcController;
    Subscription<DivinationResultIndexEvent> divination_result_subscription;
    


    private void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        Debug.Log($"DialogueRunnerFound: {dialogueRunner}");
        npcController = this.gameObject.GetComponent<NPCController>();
        divination_result_subscription = EventBus.Subscribe<DivinationResultIndexEvent>(DisplayDivinationResult);
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
        npcController.stopMoving = true;
    }

    private void DisplayDivinationResult(DivinationResultIndexEvent e)
    {
        EventBus.Publish(new DivinationResultStringEvent(DivinationResultNodes[e.index]));
    }
}