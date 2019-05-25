using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    public int maxPlatforms = 30;
    public GameObject platform;
    public GameObject cloud;
    public float horizontalMin = 0.5f;
    public float horizontalMax = 2.0f;
    public float verticalMin = -1.5f;
    public float verticalMax = 0.8f;
    private float maxDistance = 5.0f;

    private Vector2 prevPosition;
    private Vector2 initialPosition;
    private Vector2 cloudPosition;


    void Start () {

        initialPosition = transform.position;
        prevPosition = initialPosition;
        
        Spawn ();

    }

    void Spawn()
    {
      

        for (int i = 0; i < maxPlatforms; i++)
        {
            float newVertical =   Random.Range(verticalMin, verticalMax);
            float newHorizontal = Random.Range(horizontalMin, horizontalMax);
            float newXPosition = prevPosition.x + newHorizontal;
            float newYPosition = prevPosition.y + newVertical;

           

            if (newYPosition > 8)
            {
            System.Random random = new System.Random();
            int cloudAmount = random.Next(3, 10);
            cloudPosition = new Vector2(newXPosition+2f,9.5f);
                for (int j = 0; j < cloudAmount; j++)
                {
                    Instantiate(cloud, cloudPosition, Quaternion.identity);
                    cloudPosition.x = cloudPosition.x + Random.Range(4f, 5f);
                    cloudPosition.y = cloudPosition.y + Random.Range(-2f, 3.5f);
                    if (cloudPosition.y <= 8)
                        cloudPosition.y += 1f;
                }
                                newYPosition = Random.Range(5f, 8f);;
            }

            
            if (newYPosition < initialPosition.y)
            {
                newYPosition = initialPosition.y +Random.Range(0, 2f);;
            }
            Vector2 randomPosition = new Vector2 (newXPosition, newYPosition);
            Instantiate(platform, randomPosition, Quaternion.identity);
            prevPosition = randomPosition;
        }
    }


}
