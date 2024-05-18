using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour, IDataPersistence
{
    public static WeatherManager instance;
    public WeatherType currentWeather;

    private void Awake()
    {
        instance = this;
    }

    public enum WeatherType
    {
        Clear, // 50%
        Cloudy, // 25%
        Rainy, // 20%
        Foggy // 5%
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateRandomWeather()
    {
        int randomValue = Random.Range(0, 100);

        // Maybe want to add specific weather for specific day count

        if (randomValue < 50)
        {
            currentWeather = WeatherType.Clear;
        }
        else if (randomValue < 75)
        {
            currentWeather = WeatherType.Cloudy;
        }
        else if (randomValue < 95)
        {
            currentWeather = WeatherType.Rainy;
        }
        else
        {
            currentWeather = WeatherType.Foggy;
        }
    }

    public void LoadData(GameData data)
    {
        currentWeather = (WeatherType)data.weatherType;
    }

    public void SaveData(ref GameData data)
    {
        data.weatherType = (int)currentWeather;
    }

    // public void ResetData(ref GameData data)
    // {
    //     data.weatherType = 0;

    // }
}
