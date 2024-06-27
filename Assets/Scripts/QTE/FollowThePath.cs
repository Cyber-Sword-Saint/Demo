using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowThePath : MonoBehaviour
{
    public KeyCode hitKey;
    public GameObject hitPrefab;
    public TextMeshProUGUI resultText;
    public bool reverserPath = false;
    public float hitThreshold = 0.1f; // Threshold distance to consider a hit
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private GameObject[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float move_speed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypoint_index = 0;

    private bool ready_to_hit = false;

    private bool can_move = true;

    private bool hit_pressed = false;

    private Transform curr_hit_zone_transform;

    Subscription<HitZoneExitEvent> exit_hit_zone_event_subscription;

    // Use this for initialization
    private void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        exit_hit_zone_event_subscription = EventBus.Subscribe<HitZoneExitEvent>(OnHitZoneExit);
        //initialize orb position
        if (!reverserPath)
        {
            transform.position = waypoints[waypoint_index].transform.position;
        }

        else
        {
            transform.position = waypoints[waypoints.Length - 1].transform.position;
            waypoint_index = waypoints.Length - 1;
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (can_move) { Move(); }

        if (can_move && ready_to_hit)
        {
            hit_pressed = false;
            // If hit button is pressed
            if (Input.GetKeyDown(hitKey))
            {
                hit_pressed = true;
               GameObject hitMark =  Instantiate(hitPrefab, GetComponentInParent<Transform>().position, Quaternion.identity);
                hitMark.transform.parent = this.gameObject.transform.parent;
                ready_to_hit = false;
                CheckHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HitPoint>() != null)
        {
            ready_to_hit = true;
            curr_hit_zone_transform = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HitPoint>() != null)  
        {
            ready_to_hit = false;
            //Publish Exit Event for calling checkhit
            EventBus.Publish(new HitZoneExitEvent());
        }
    }



    private void Move()
    {
        // If orb didn't reach last waypoint it can move
        // If orb reached last waypoint then it stops
        if (!reverserPath) { 
            if (waypoint_index < waypoints.Length)
            {
                can_move = true;
                // Move orb from current waypoint to the next one
                // using MoveTowards method
                transform.position = Vector3.MoveTowards(transform.position,
                   waypoints[waypoint_index].transform.position,
                   move_speed * Time.deltaTime);
                // If orb reaches position of waypoint he walked towards
                // then waypointIndex is increased by 1
                // and  starts to walk to the next waypoint
                if (transform.position == waypoints[waypoint_index].transform.position)
                {
                    waypoint_index += 1;
                }
            }
            else
            {
                can_move = false;
                EventBus.Publish(new QteEndEvent());
            }
        }

        else
        {
            if(waypoint_index > 0)
            {
                can_move = true;
                transform.position = Vector3.MoveTowards(transform.position,
                    waypoints[waypoint_index].transform.position,
                    move_speed * Time.deltaTime);
            }
            else
            {
                can_move = false;
                EventBus.Publish(new QteEndEvent());
            }

            if(transform.position == waypoints[waypoint_index].transform.position)
            {
                waypoint_index -= 1;
            }
        }
    }
  
    void CheckHit()
    {
        Transform targetWaypoint = curr_hit_zone_transform;
        float distance = Vector2.Distance(transform.position, targetWaypoint.position);
        string curr_result = "";

        if (distance <= hitThreshold)
        {
            Debug.Log("Perfect!");
            curr_result = "Perfect!";
        }
        else if (distance <= hitThreshold * 3f)
        {
            Debug.Log("Excellent!");
            curr_result = "Excellent!";
        }
        else if (distance <= hitThreshold * 5f)
        {
            Debug.Log("Fair!");
            curr_result = "Fair!";
        }
        else
        {
            Debug.Log("Fail!");
            curr_result = "Fail!";
        }

        EventBus.Publish(new HitZoneResultEvent(curr_result,(1-distance)));
    }

    void OnHitZoneExit(HitZoneExitEvent e)
    {
        string curr_result = "";
        if (!hit_pressed)
        {
            Debug.Log("Missed!");
            curr_result = "Miss!";
            EventBus.Publish(new HitZoneResultEvent(curr_result,0));
        }
    }
}
