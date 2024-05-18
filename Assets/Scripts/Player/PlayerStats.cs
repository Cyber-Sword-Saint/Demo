using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stat SoulPoint;
    public Stat DivinationSkill;
    public Stat GatheringSkill;
    Subscription<DivinationEvent> divination_event_subscription;

    private void Awake()
    {
        SoulPoint = new Stat("soul points", 0, 100, 100);
        DivinationSkill = new Stat("divination ability", 0, 0, 1000);
        GatheringSkill = new Stat("gethering skill", 0, 0, 1000);
        divination_event_subscription = EventBus.Subscribe<DivinationEvent>(DivinationStatChange);
    }
    private void Start()
    {
       
    }

    private void Update()
    {
        
    }

    // consumes sp and increase proficiency
    private void DivinationStatChange(DivinationEvent e)
    {
        DivinationSkill.IncreaseCurrentValue(e.proficiencyIncrease);
        SoulPoint.DecreaseCurrentValue(e.soulPointsDecrease); 
    }
}


