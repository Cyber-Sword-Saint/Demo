using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    // private string dataFileName = "";
    private string[] dataFileNames;

    public FileDataHandler(string dataDirPath, string[] dataFileNames)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileNames = dataFileNames;
    }

    public GameData Load(int saveSlot)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileNames[saveSlot].ToString());
        Debug.Log("Path: " + fullPath);

        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            Debug.Log("Path exists");
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                        Debug.Log("Load successfully1");
                    }
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
                
            }
            catch (Exception e)
            {
                Debug.LogError("Error occurred when try to load data from file: " 
                + fullPath + "\n" + e);

            }
        } else {
            Debug.Log("Path not exists");
        }

        Debug.Log("Load successfully2");
        return loadedData;

    }

    public void Save(GameData data, int saveSlot)
    {
        Debug.Log("save slot:" + saveSlot);
        string fullPath = Path.Combine(dataDirPath, dataFileNames[saveSlot].ToString());
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                    Debug.Log("slot " + saveSlot +  " saved");
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occurred when try to save data to file: " + fullPath + "\n" + e);

        }
    }

    public void Delete(int saveSlot)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, dataFileNames[saveSlot].ToString());
        if (File.Exists(fullPath))
        {
            try
            {
                File.Delete(fullPath);
                Debug.Log("Save slot " + saveSlot + " deleted successfully.");
            }
            catch (Exception e)
            {
                Debug.LogError("Error occurred when trying to delete save slot " + saveSlot + ": " + e);
            }
        }
        else
        {
            Debug.LogWarning("Save slot " + saveSlot + " not found.");
        }
    }

}
