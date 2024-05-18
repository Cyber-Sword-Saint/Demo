using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stat SoulPoints;
    public Stat DivinationSkill;
    public Stat GatheringSkill;
    public Stat MovementSpeed;
    Subscription<DivinationEvent> divination_event_subscription;
    Subscription<PickupEvent> pick_up_event_subscription;

    private void Awake()
    {
        // Initialize playerStats
        SoulPoints = new Stat("soul points", 0, 100, 100);
        DivinationSkill = new Stat("divination ability", 0, 1000, 0);
        GatheringSkill = new Stat("gethering skill", 0, 1000,0);
        MovementSpeed = new Stat("movement speed", 2, 5, 5);

        // Event Subscription
        divination_event_subscription = EventBus.Subscribe<DivinationEvent>(DivinationStatChange);
        pick_up_event_subscription = EventBus.Subscribe<PickupEvent>(GatheringSkillStatChange);
        
    }

    private void Start()
    {
       
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// consumes sp and increase divination proficiency
    /// </summary>
    /// <param name="e"></param>
    private void DivinationStatChange(DivinationEvent e)
    {
        DivinationSkill.IncreaseCurrentValue(e.proficiencyIncrease);
        Debug.Log($"Divination Skill: {DivinationSkill.currVal}");
        // TODO handle skill points + leveling up

        SoulPoints.DecreaseCurrentValue(e.soulPointsDecrease);
        Debug.Log($"Soul Points: {SoulPoints.currVal}");
        // TODO handle skill points + leveling up
    }

    /// <summary>
    /// increases gathering proficiency
    /// </summary>
    /// <param name="e"></param>
    private void GatheringSkillStatChange(PickupEvent e)
    {
        GatheringSkill.IncreaseCurrentValue(e.proficiencyIncrease);
        Debug.Log($"Gathering Skill: {GatheringSkill.currVal}");

        // TODO hange skill points + leveling up
    }
}


