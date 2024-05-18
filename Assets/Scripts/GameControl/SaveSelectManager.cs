using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSelectManager : MonoBehaviour
{
    public Button saveSlot1Button;
    public Button saveSlot2Button;
    public Button saveSlot3Button;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSaveSlotButton(saveSlot1Button, 0);
        UpdateSaveSlotButton(saveSlot2Button, 1);
        UpdateSaveSlotButton(saveSlot3Button, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSaveSlotButton(Button button, int saveSlot)
    {
        GameData loadedData = DataPersistenceManager.instance.LoadGame(saveSlot);
        if (loadedData != null)
        {
            if (loadedData.dayCount == 1)
            {
                button.GetComponentInChildren<Text>().text = "New Game";
            }
            else
            {
                button.GetComponentInChildren<Text>().text = "Day " + loadedData.dayCount;
            }
            
            // button.onClick.AddListener(() => LoadSaveGame(saveSlot));
        }
        else
        {
            button.GetComponentInChildren<Text>().text = "New Game";
            // button.onClick.AddListener(() => NewGame(saveSlot));
        }
    }

    public void DeleteSaveSlot(int saveSlot)
    {
        DataPersistenceManager.instance.DeleteData(saveSlot);
        UpdateSaveSlotButton(GetSaveSlotButton(saveSlot), saveSlot);
    }

    Button GetSaveSlotButton(int saveSlot)
    {
        switch (saveSlot)
        {
            case 0:
                return saveSlot1Button;
            case 1:
                return saveSlot2Button;
            case 2:
                return saveSlot3Button;
            default:
                return null;
        }
    }
}
