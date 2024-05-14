using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public GameObject objectToGenerate; 
    public Vector3 minPosition;
    public Vector3 maxPosition;

    void Start()
    {
        GenerateRandomObject();
    }

    void GenerateRandomObject()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z)
        );

        Instantiate(objectToGenerate, randomPosition, Quaternion.identity);
    }
}
