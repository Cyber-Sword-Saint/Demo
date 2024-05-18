using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    // [SerializeField] private string fileName;
    [SerializeField] private string[] fileNames;
    public int currentSaveSlot;
    private List<IDataPersistence> dataPersistenceObjects;
    private int listCount;
    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance
    {
        get;
        private set;
    }

    private GameData gameData;
    

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileNames);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        listCount = dataPersistenceObjects.Count();
        LoadGame(currentSaveSlot);
    }

    public void NewGame(int saveSlot)
    {
        Debug.Log("New Game");

        this.gameData = new GameData();
        InventorySaveManager.instance.ResetData();
    }

    public void LoadGame(int saveSlot)
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileNames);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();

        
        Debug.Log("Load Game: " + saveSlot);
        this.currentSaveSlot = saveSlot;
        this.gameData = dataHandler.Load(saveSlot);

        if (this.gameData == null)
        {
            Debug.Log("No saved data");
            NewGame(saveSlot);
            // SaveGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            Debug.Log("foreach load");
            dataPersistenceObj.LoadData(gameData);
            Debug.Log(dataPersistenceObj.ToString());

        }
    }

    public void SaveGame()
    {
        Debug.Log("Save");

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileNames);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();


        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            Debug.Log("foreach save");
            dataPersistenceObj.SaveData(ref gameData);
            Debug.Log(dataPersistenceObj.ToString());
        }

        dataHandler.Save(gameData, currentSaveSlot);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
        .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
