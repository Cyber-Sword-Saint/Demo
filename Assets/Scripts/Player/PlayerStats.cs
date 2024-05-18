using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stat SoulPoints;
    public Stat DivinationSkill;
    public Stat GatheringSkill;
    public Stat MovementSpeed;
    [SerializeField]
    public string currDivinationTitle;
    public string currDivinationLevelDescription;
    public string currGatheringTitle;
    public string currGatheringLevelDescription;
    public List<string> DivinationTitle;
    public List<string> DivinationLevelDescription;
    public List<string> GatheringTitle;
    public List<string> GatheringLevelDescription;
    Subscription<DivinationEvent> divination_event_subscription;
    Subscription<PickupEvent> pick_up_event_subscription;

    private void Awake()
    {
        // Initialize playerStats
        SoulPoints = new Stat("soul points", 0, 100, 100);
        DivinationSkill = new Stat("divination ability", 0, 1000, 0);
        GatheringSkill = new Stat("gethering skill", 0, 900,0);
        MovementSpeed = new Stat("movement speed", 2, 5, 5);

        // Event Subscription
        divination_event_subscription = EventBus.Subscribe<DivinationEvent>(DivinationStatChange);
        pick_up_event_subscription = EventBus.Subscribe<PickupEvent>(GatheringSkillStatChange);

        // Initialize skill title and description
        currDivinationTitle = DivinationTitle[0];
        currDivinationLevelDescription = DivinationLevelDescription[0];
        currGatheringTitle = GatheringTitle[0];
        currGatheringLevelDescription = GatheringLevelDescription[0];
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
        // handle skill points + leveling up
        if(DivinationSkill.currVal == 120)
        {
            //TODO level 2
            currDivinationTitle = DivinationTitle[1];
            currDivinationLevelDescription = DivinationLevelDescription[1];
        }

        if(DivinationSkill.currVal == 500)
        {
            //TODO level 3
            currDivinationTitle = DivinationTitle[2];
            currDivinationLevelDescription = DivinationLevelDescription[2];
        }

        if(DivinationSkill.currVal == 1000)
        {
            //TODO level 4
            currDivinationTitle = DivinationTitle[3];
            currDivinationLevelDescription = DivinationLevelDescription[3];
        }

        SoulPoints.DecreaseCurrentValue(e.soulPointsDecrease);
        Debug.Log($"Soul Points: {SoulPoints.currVal}");
        // handle skill points + leveling up


    }

    /// <summary>
    /// increases gathering proficiency
    /// </summary>
    /// <param name="e"></param>
    private void GatheringSkillStatChange(PickupEvent e)
    {
        GatheringSkill.IncreaseCurrentValue(e.proficiencyIncrease);
        Debug.Log($"Gathering Skill: {GatheringSkill.currVal}");

        // handle skill points + leveling up
        if(GatheringSkill.currVal == 150)
        {
            // TODO level 2
            currGatheringTitle = GatheringTitle[1];
            currGatheringLevelDescription = GatheringLevelDescription[1];
        }

        if(GatheringSkill.currVal == 450)
        {
            // TODO level 3
            currGatheringTitle = GatheringTitle[1];
            currGatheringLevelDescription = GatheringLevelDescription[1];
        }

        if(GatheringSkill.currVal == 900)
        {
            // TODO level 4
            currGatheringTitle = GatheringTitle[1];
            currGatheringLevelDescription = GatheringLevelDescription[1];
        }

    }
}


