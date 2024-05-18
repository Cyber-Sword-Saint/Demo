using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionalStats : MonoBehaviour
{
    public Stat FaithValue;
    // Start is called before the first frame update
    void Start()
    {
        FaithValue = new Stat("faith value", -100, 999, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
