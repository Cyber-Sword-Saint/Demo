using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepUI : MonoBehaviour
{
    
    public GameObject sleepScreen;
    public Text dayText;
    public float blackoutDuration = 2.0f; 
    public float delayBeforeUpdate = 1.0f;
    private int currentDay;

    public static SleepUI instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sleepScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentDay = DayCount.instance.dayCount;
    }

    public void StartSleepScene()
    {
        sleepScreen.SetActive(true);
        StartCoroutine(UpdateDayAfterDelay());

        Invoke("HideBlackout", blackoutDuration);
    }

    private IEnumerator UpdateDayAfterDelay()
    {
        // currentDay--;
        UpdateDayText();
        yield return new WaitForSeconds(delayBeforeUpdate);

        // currentDay++;
        UpdateDayText();

        yield return new WaitForSeconds(blackoutDuration - delayBeforeUpdate);
        sleepScreen.SetActive(false);
    }

    private void UpdateDayText()
    {
        dayText.text = currentDay.ToString();
    }

    private void HideBlackout()
    {
        sleepScreen.SetActive(false);
    }
}
