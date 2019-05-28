using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class EnemySpawner : MonoBehaviour
{
    public Transform[] enemyPointsSpawns;
    public GameObject enemy;

    private int MaxEnemyOnGround = 2;
    // Use this for initialization
    void Start () {

        Spawn();
        
    }

  

    void Spawn()
    {
        System.Random random = new System.Random();
        for (int i = 0; i < MaxEnemyOnGround; i++)
        {
            Transform enemyPosition = null;
            int prevPosition = -1;
            int randomPosition=0;
            int enemyFlip = random.Next (0, 5);
            if (enemyFlip >= 2)
            {
                randomPosition = random.Next(0, enemyPointsSpawns.Length - 1);


                if (randomPosition != prevPosition)
                {
                    prevPosition = randomPosition;
                    enemyPosition = enemyPointsSpawns[randomPosition];
                    Instantiate(enemy, enemyPosition.position, Quaternion.identity);
                }
            }
        }
    }
   
}
