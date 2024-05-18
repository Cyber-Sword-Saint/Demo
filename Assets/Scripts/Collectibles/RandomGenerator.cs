using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public List<GameObject> objectsToGenerate = new List<GameObject>(); 
    public Vector3 minPosition;
    public Vector3 maxPosition;
    public static RandomGenerator instance;

    private List<GameObject> generatedObjects = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GenerateRandomObject();
    }

    public void OnPlayerSleep()
    {
        if (generatedObjects != null)
        {
            foreach (GameObject generatedObject in generatedObjects)
            {
                Destroy(generatedObject);
            }
            
        }

        GenerateRandomObject();
    }

    void GenerateRandomObject()
    {
        generatedObjects = new List<GameObject>();

        foreach (GameObject objectToGenerate in objectsToGenerate)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(minPosition.x, maxPosition.x),
                Random.Range(minPosition.y, maxPosition.y),
                Random.Range(minPosition.z, maxPosition.z)
            );

            generatedObjects.Add(Instantiate(objectToGenerate, randomPosition, Quaternion.identity));
        }
        
    }


}
