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
    public Chest ChestInventory;
    private int saveSlot;
    [SerializeField] private string[] fileNames;
    private string fullPath;
    public static InventorySaveManager instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        saveSlot = DataPersistenceManager.instance.currentSaveSlot;
        fullPath = Path.Combine(Application.persistentDataPath, fileNames[saveSlot].ToString());
    }
    public void LoadData(GameData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        SetFullPath(DataPersistenceManager.instance.currentSaveSlot);
        Debug.Log(fullPath);

        if (File.Exists(fullPath))
        {
            FileStream file = File.Open(fullPath, FileMode.Open);
            
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), myInventory);
            file.Close();
        }

        if (File.Exists(Application.persistentDataPath + "/chest.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/chest.txt", FileMode.Open);
            
            if (this.ChestInventory != null)
            {
                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), this.ChestInventory);
                file.Close();
            }
            else
            {
                Debug.Log("chestInventory is null!");
            }
            
        }
    }

    public void SaveData(ref GameData data)
    {
        SetFullPath(DataPersistenceManager.instance.currentSaveSlot);
        Debug.Log(fullPath);

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file1 = File.Create(fullPath);
        FileStream file2 = File.Create(Application.persistentDataPath + "/chest.txt");


        var json1 = JsonUtility.ToJson(myInventory);
        var json2 = JsonUtility.ToJson(ChestInventory);

        formatter.Serialize(file1, json1);
        formatter.Serialize(file2, json2);

        file1.Close();
        file2.Close();

    }

    public void ResetData(int saveSlot)
    {
        myInventory.Clear();
        
        Debug.Log("Reset");

        SetFullPath(saveSlot);

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(fullPath);

        var json = JsonUtility.ToJson(myInventory);
        formatter.Serialize(file, json);

        file.Close();
    }

    void SetFullPath(int saveSlot)
    {
        fileNames = new string[] {"inventory1", "inventory2", "inventory3"};
        fullPath = Path.Combine(Application.persistentDataPath, fileNames[saveSlot].ToString());
    }
}
