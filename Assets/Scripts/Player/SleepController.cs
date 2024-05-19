using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepController : MonoBehaviour
{
    private int dayCount;
    // public GameObject dayDisplay;
    private bool isInRange;
    public KeyCode sleepKey = KeyCode.E;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnPlayerSleep(); 
    }

    private void OnPlayerSleep()
    {
        if ((Input.GetKeyDown(sleepKey) && isInRange))
        {
            RandomGenerator.instance.OnPlayerSleep();          
            DayCount.instance.OnPlayerSleep();
            ChestRefreshController.instance.OnPlayerSleep();
            DataPersistenceManager.instance.SaveGame();
            SleepUI.instance.StartSleepScene();
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
    }
}
