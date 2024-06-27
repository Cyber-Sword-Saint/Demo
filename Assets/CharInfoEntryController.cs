using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharInfoEntryController : MonoBehaviour
{
    public VerticalLayoutGroup verticalLayoutGroup;
    public GameObject InfoEntryPrefab;
    [SerializeField]
    private List<NPCInfo> currNPCInfoList;
    [SerializeField]
    private string NPCName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCurrNPCInfo(NPCProfile currProfile)
    {
        Debug.Log("showing char info");
        NPCName = currProfile.npcName;
        Debug.Log($"NPC name: {NPCName}");
        currNPCInfoList = currProfile.npcInfoList;
        Debug.Log($"NPCInfoList {currNPCInfoList}");
        foreach (NPCInfo entry in currNPCInfoList)
        {
            GameObject curr_info = Instantiate(InfoEntryPrefab, verticalLayoutGroup.gameObject.transform);
            if (entry.isCollected)
            {
                curr_info.GetComponent<TextMeshProUGUI>().text = entry.infoDescription;
            }
            else
            {
                curr_info.GetComponent<TextMeshProUGUI>().text = "???";
            }
        }
    }
   
}
