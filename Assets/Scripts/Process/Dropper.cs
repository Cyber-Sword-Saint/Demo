using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public GameObject itemToDrop;
    public Transform tablePosition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Drop());

    }
    

    // Update is called once per frame
    void Update()
    {
    }
        
    public IEnumerator Drop()
    {
        float duration = 0.5f;
        Vector3 startPosition = itemToDrop.transform.position;
        Vector3 endPosition = tablePosition.position;
        float elapsed = 0;

        while (elapsed < duration)
        {
            itemToDrop.transform.position = Vector3.Lerp(startPosition, endPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        itemToDrop.transform.position = endPosition;
    }
}
