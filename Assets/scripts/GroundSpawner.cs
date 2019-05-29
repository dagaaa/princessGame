using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxGrounds = 20;
    public GameObject ground;
    public GameObject wayPoint = null;
    public float width = 10.24f;

    private Vector2 originPosition;


    void Start()
    {
        originPosition = transform.position;
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < maxGrounds; i++)
        {
            Vector2 nextPosition = new Vector2(originPosition.x + width, originPosition.y);
            Instantiate(ground, nextPosition, Quaternion.identity);

            if (wayPoint != null)
            {
                Vector2 nextWayPointPosition = new Vector2(originPosition.x + (1.5f * width), originPosition.y + 1f);
                Instantiate(wayPoint, nextWayPointPosition, Quaternion.identity);
            }

            originPosition = nextPosition;
        }
    }
}