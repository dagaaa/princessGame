using System;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    
    [SerializeField]
    private Transform[] waypoints;

    private float TOLERANCE = 0.1f;
    
    [SerializeField]
    private float moveSpeed = 2f;
    private int waypointIndex = 0;

  
    private void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update () {

        Move();
    }


    private void Move()
    {
  
        if (waypointIndex <= waypoints.Length - 1)
        {

            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed );

            if (Math.Abs(transform.position.x - waypoints[waypointIndex].transform.position.x) < TOLERANCE)
            {
                waypointIndex += 1;
            }
        }
    }
}
