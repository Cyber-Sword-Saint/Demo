using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    public bool reverserPath = false;
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private GameObject[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    // Use this for initialization
    private void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        // Set position of Enemy as position of the first waypoint
        if (!reverserPath)
        {
            transform.position = waypoints[waypointIndex].transform.position;
        }

        else
        {
            transform.position = waypoints[waypoints.Length - 1].transform.position;
            waypointIndex = waypoints.Length - 1;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // If orb didn't reach last waypoint it can move
        // If orb reached last waypoint then it stops
        if (!reverserPath)
        {
            if (waypointIndex < waypoints.Length)
            {
                Debug.Log($"movetowards {waypointIndex}");
                // Move orb from current waypoint to the next one
                // using MoveTowards method
                transform.position = Vector3.MoveTowards(transform.position,
                   waypoints[waypointIndex].transform.position,
                   moveSpeed * Time.deltaTime);
                // If orb reaches position of waypoint he walked towards
                // then waypointIndex is increased by 1
                // and  starts to walk to the next waypoint
                if (transform.position == waypoints[waypointIndex].transform.position)
                {
                    Debug.Log($"reached {waypointIndex}");
                    waypointIndex += 1;
                }
            }
        }

        else
        {
            if(waypointIndex > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    waypoints[waypointIndex].transform.position,
                    moveSpeed * Time.deltaTime);
            }

            if(transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex -= 1;
            }
        }
    }
}
