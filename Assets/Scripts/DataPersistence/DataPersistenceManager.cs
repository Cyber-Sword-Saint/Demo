using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance
    {
        get;
        private set;
    }

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        Debug.Log("New Game");

        this.gameData = new GameData();
        InventorySaveManager.instance.ResetData();
    }

    public void LoadGame()
    {
        Debug.Log("Load Game");
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No saved data");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        Debug.Log("Save");

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
        .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
