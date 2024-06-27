using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;

public class NoticeBoardController : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    public GameObject NoticeBoardPanel;
    public VerticalLayoutGroup verticalLayoutGroup;
    public GameObject InfoEntryPrefab;
    public List<NPCInfo> NPCInfoList;
    [SerializeField]
    private bool playerInRange = false;
    private DialogueRunner dialogueRunner;
    // Start is called before the first frame update
    void Start()
    {
        foreach (NPCInfo entry in NPCInfoList)
        {
            GameObject curr_info = GameObject.Instantiate(InfoEntryPrefab,verticalLayoutGroup.gameObject.transform);
            curr_info.GetComponent<TextMeshProUGUI>().text = entry.infoDescription;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            Debug.Log("toggle notice board ui");
            //TODO notice board UI toggle
            if (NoticeBoardPanel.activeSelf)
            {
                NoticeBoardPanel.SetActive(false);
            }

            else
            {
                // set char Info to be collected 
                NoticeBoardPanel.SetActive(true);
                foreach (NPCInfo entry in NPCInfoList)
                {
                    entry.isCollected = true;
                }
            }
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
