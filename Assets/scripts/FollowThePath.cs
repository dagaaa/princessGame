using System;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowThePath : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    private float TOLERANCE = 0.1f;

    [SerializeField] private float moveSpeed = 2f;
    private int waypointIndex = 0;


    private void Start()
    {
        foreach (var waypoint in waypoints)
        {
            var transformPosition = transform.position;
            waypoint.position = new Vector3(
                Math.Abs(waypoint.position.x + transformPosition.x),
                transformPosition.y,
                transformPosition.z);
        }

        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i].position == transform.position)
            {
                waypointIndex = i;
                return;
            }
        }
    }

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed);

        if (Math.Abs(transform.position.x - waypoints[waypointIndex].transform.position.x) < TOLERANCE)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }
}