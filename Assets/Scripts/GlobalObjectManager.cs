using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalObjectManager : MonoBehaviour
{
    public static GlobalObjectManager instance;
    public DayCount dayCount;

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
}
