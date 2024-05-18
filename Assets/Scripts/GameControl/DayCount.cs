using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayCount : MonoBehaviour, IDataPersistence
{
    public int dayCount = 0;
    private Text dayCountText;
    public static DayCount instance;
    private void Awake()
    {
        dayCountText = this.GetComponent<Text>();
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dayCountText.text = "" + dayCount;
    }

    public void OnPlayerSleep()
    {
        dayCount++;
        WeatherManager.instance.GenerateRandomWeather();
    }

    public void LoadData(GameData data)
    {
        this.dayCount = data.dayCount;
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log("Day " + dayCount);
        data.dayCount = dayCount;
    }
    
    // public void ResetData(ref GameData data)
    // {
    //     data.dayCount = 1;

    // }
}
