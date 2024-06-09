using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HitZoneResultUI : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    Subscription<HitZoneResultEvent> hit_zone_result_subscription;
    Subscription<QteEndEvent> qte_end_subscription;
    [SerializeField]
    List<float> resultList;
    float overallAccuracy;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        hit_zone_result_subscription = EventBus.Subscribe<HitZoneResultEvent>(UpdateResultUI);
        qte_end_subscription = EventBus.Subscribe<QteEndEvent>(ShowFinalResult);
    }

    void UpdateResultUI(HitZoneResultEvent e)
    {
        //Update the current display
        textMeshPro.text = e.message;
        //Update reuslt list for final calculation;
        if(e.message.Length != 0)
        {
            resultList.Add(e.accuracy);
        }
    }

    void ShowFinalResult(QteEndEvent e)
    {
        string msg = "";
        foreach (float result in resultList)
        {
            overallAccuracy += result;
        }

        overallAccuracy /= resultList.Count;
        overallAccuracy *= 100;
        double roundedAccuracy = Math.Round(overallAccuracy, 2);
        Debug.Log($"overall accuracy {roundedAccuracy}%");

       
        if(overallAccuracy > 80)
        {
            msg = $"Perfect Divination \n You achieved {roundedAccuracy}% on accuracy.";
        }

        else if (overallAccuracy > 60)
        {
            msg = $"Excellent Divination \n You achieved {roundedAccuracy}% on accuracy.";
        }

        else if (overallAccuracy > 40)
        {
            msg = $"Average Divination \n You achieved {roundedAccuracy}% on accuracy.";
        }

        else
        {
            msg = $"Failed Divination \n You achieved {roundedAccuracy}% on accuracy.";
        }

        textMeshPro.text = msg;
    }
}
