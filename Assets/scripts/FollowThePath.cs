using System;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowThePath : MonoBehaviour
{
    
    [SerializeField]
    private Transform[] waypoints;

    private float TOLERANCE = 0.1f;
    
    [SerializeField]
    private float moveSpeed = 2f;
    private int waypointIndex = 0;

  
    private void Start () {
//        transform.position = waypoints[waypointIndex].transform.position;
        Vector3 currentPosition;
        for (int i = 0; i < waypoints.Length; i++)
        {
           currentPosition = new Vector3(waypoints[i].position.x + transform.position.x,transform.position.y,0);
           waypoints[i].position = currentPosition;
        }
            
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i].position == transform.position)
                waypointIndex = i;
        }
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
