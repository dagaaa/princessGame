using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    public int maxPlatforms = 20;
    public GameObject platform;
    public float horizontalMin = 1.5f;
    public float horizontalMax = 3.5f;
    public float verticalMin = -3f;
    public float verticalMax = 1.5f;


    private Vector2 originPosition;


    void Start () {

        originPosition = transform.position;
        Spawn ();

    }

    void Spawn()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            float newHorizontal = originPosition.x+Random.Range(horizontalMin, horizontalMax);
            float newVertical = Math.Max(0.5f, originPosition.y + Random.Range(verticalMin, verticalMax));
            Vector2 randomPosition = new Vector2 (newHorizontal, newVertical);
            Instantiate(platform, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }

}
