using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HitZoneResultUI : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    Subscription<HitZoneResultEvent> hit_zone_result_subscription;
    [SerializeField]
    List<string> resultList;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        hit_zone_result_subscription = EventBus.Subscribe<HitZoneResultEvent>(UpdateResultUI);
    }

    void UpdateResultUI(HitZoneResultEvent e)
    {
        //Update the current display
        textMeshPro.text = e.message;
        //Update reuslt list for final calculation;
        if(e.message.Length != 0)
        {
            resultList.Add(e.message);
        }
    }
}
