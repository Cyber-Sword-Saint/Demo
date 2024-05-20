using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using Yarn.Unity;

public class NoticeBoardController : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    private bool playerInRange = false;
    private DialogueRunner dialogueRunner;
    List<NPCInfo> NPCInfoList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            //TODO notice board UI toggle
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

}
