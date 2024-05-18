using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class InventorySaveManager : MonoBehaviour, IDataPersistence
{
    public BasicInventory myInventory;
    public Chest chestInventory;

    public static InventorySaveManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void LoadData(GameData data)
    {
        BinaryFormatter bf = new BinaryFormatter();

        if (File.Exists(Application.persistentDataPath + "/inventory.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/inventory.txt", FileMode.Open);
            
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), myInventory);
            file.Close();
        }

        if (File.Exists(Application.persistentDataPath + "/chest.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/chest.txt", FileMode.Open);
            
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), chestInventory);
            file.Close();
        }
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log(Application.persistentDataPath);

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file1 = File.Create(Application.persistentDataPath + "/inventory.txt");
        FileStream file2 = File.Create(Application.persistentDataPath + "/chest.txt");


        var json1 = JsonUtility.ToJson(myInventory);
        var json2 = JsonUtility.ToJson(chestInventory);

        formatter.Serialize(file1, json1);
        formatter.Serialize(file2, json2);

        file1.Close();
        file2.Close();

    }

    public void ResetData()
    {
        myInventory.Clear();
        
        Debug.Log("Reset");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/inventory.txt");

        var json = JsonUtility.ToJson(myInventory);
        formatter.Serialize(file, json);

        file.Close();
    }
}
