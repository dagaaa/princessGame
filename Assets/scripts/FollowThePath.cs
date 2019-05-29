using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class FollowThePath : MonoBehaviour
{
    private GameObject[] dynamicWayPoints;

    private float TOLERANCE = 0.1f;

    [SerializeField] private float moveSpeed = 2f;
    private int waypointIndex = 0;
    private Random _random = new Random();
    private bool facingRight = true;


    private void Start()
    {
        dynamicWayPoints = GameObject.FindGameObjectsWithTag("WayPoint");

        foreach (var waypoint in dynamicWayPoints)
        {
            var transformPosition = transform.position;
            waypoint.transform.position = new Vector3(
                Math.Abs(waypoint.transform.position.x + transformPosition.x),
                transformPosition.y,
                transformPosition.z);
        }

        for (int i = 0; i < dynamicWayPoints.Length; i++)
        {
            if (dynamicWayPoints[i].transform.position == transform.position)
            {
                waypointIndex = i;
                return;
            }
        }
    }

    private void Update()
    {
        if (dynamicWayPoints.Length < 3)
        {
            dynamicWayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            dynamicWayPoints[waypointIndex].transform.position,
            moveSpeed * Time.timeScale);

        if (Math.Abs(transform.position.x - dynamicWayPoints[waypointIndex].transform.position.x) < TOLERANCE)
        {
            if (_random.Next(0, 2) == 0)
            {
                SetNextRightIndex(waypointIndex + 1, waypointIndex - 1);
            }
            else
            {
                SetNextLeftIndex(waypointIndex - 1, waypointIndex + 1);
            }
        }
    }

    private void SetNextRightIndex(int nextIndex, int fallbackIndex)
    {
        if (nextIndex <= dynamicWayPoints.Length - 1)
        {
            waypointIndex = nextIndex;
            if (!facingRight)
            {
                Flip();
            }
        }
        else
        {
            waypointIndex = fallbackIndex;
            if (facingRight)
            {
                Flip();
            }
        }
    }

    private void SetNextLeftIndex(int nextIndex, int fallbackIndex)
    {
        if (nextIndex >= 0)
        {
            waypointIndex = nextIndex;
            if (facingRight)
            {
                Flip();
            }
        }
        else
        {
            waypointIndex = fallbackIndex;
            if (!facingRight)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}