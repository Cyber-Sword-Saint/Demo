using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestRefreshController : MonoBehaviour
{
    public Chest chestInventory;
    public List<Item> itemToGenerate = new List<Item>();
    public List<int> itemNumToGenerate = new List<int>();

    public List<Item> itemChose = new List<Item>();
    public List<int> itemNumChose = new List<int>();

    public static ChestRefreshController instance;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // OnPlayerSleep()
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerSleep()
    {
        GenerateRandomItemList();

        chestInventory.itemList = new List<Item>(itemChose);
        chestInventory.itemNumList = new List<int>(itemNumChose);
    }

    private void GenerateRandomItemList()
    {

        itemChose = new List<Item>();
        itemNumChose = new List<int>();

        System.Random random = new System.Random();
        int minValue = 1;
        int maxValue = 6;

        int itemAmount = random.Next(minValue, maxValue + 1);

        HashSet<int> generatedIndices = new HashSet<int>();

        while (generatedIndices.Count < itemAmount)
        {
            int itemIndex = random.Next(minValue, maxValue + 1);
            if (!generatedIndices.Contains(itemIndex))
            {
                generatedIndices.Add(itemIndex);
                itemChose.Add(itemToGenerate[itemIndex - 1]);
                itemNumChose.Add(itemNumToGenerate[itemIndex - 1]);
            }
        }
    }
}
