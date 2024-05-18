using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayCount : MonoBehaviour, IDataPersistence
{
    public int dayCount;
    private Text dayCountText;
    // public static DayCount instance;
    private void Awake()
    {
        dayCountText = this.GetComponent<Text>();
        GlobalObjectManager.instance.dayCount = this;
        Refresh();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Refresh()
    {
        DataPersistenceManager.instance.LoadGame(DataPersistenceManager.instance.currentSaveSlot);
        dayCountText.text = "" + dayCount;
    }

    public void OnPlayerSleep()
    {
        dayCount++;
        WeatherManager.instance.GenerateRandomWeather();
        dayCountText.text = "" + dayCount;
    }

    public void LoadData(GameData data)
    {
        this.dayCount = data.dayCount;
        Debug.Log("Load: Day " + dayCount);
        
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log("Save: Day " + dayCount);
        data.dayCount = dayCount;
        dayCountText.text = "" + dayCount;

    }
    
    // public void ResetData(ref GameData data)
    // {
    //     data.dayCount = 1;

    // }
}
