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
    [SerializeField]
    private bool canBeDiabledByPlayerInput = false;
    Subscription<QteStartEvent> qte_start_subscription;
    Subscription<QteEndEvent> qte_end_subscription;
    Subscription<DivinationResultStringEvent> divination_result_subscriptoin;
    [SerializeField]
    private string resultDialogueNode = "";
    public GameObject bayleaf;
    
    // Start is called before the first frame update
    void Start()
    {
        miniGameController = view.GetComponent<MiniGameController>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        dialogueRunner.AddCommandHandler("run_mini_game", RunMiniGame);
        qte_start_subscription = EventBus.Subscribe<QteStartEvent>(StartQTE);
        qte_end_subscription = EventBus.Subscribe<QteEndEvent>(OnQteEnd);
        divination_result_subscriptoin = EventBus.Subscribe<DivinationResultStringEvent>(OnDivinationResultReceived);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && canBeDiabledByPlayerInput)
        {
            if(view.activeSelf)
            {
                ClosePanel();
                if (resultDialogueNode.Length > 0)
                {
                    dialogueRunner.StartDialogue(resultDialogueNode);
                }
            }
        }
    }

    void RunMiniGame()
    {
        //OpenPanel();
        bayleaf.SetActive(true);
    }

    public void StartQTE(QteStartEvent e)
    {
        OpenPanel();
    }

    void OpenPanel()
    {
        view.SetActive(true);
    }

    void ClosePanel()
    {
        //miniGameController.RestGame();
        view.SetActive(false);
    }

    void OnQteEnd(QteEndEvent e)
    {
        canBeDiabledByPlayerInput = true;
    }

    void OnDivinationResultReceived(DivinationResultStringEvent e)
    {
        //TODO
        resultDialogueNode = e.nodeName;
    }
    
}
