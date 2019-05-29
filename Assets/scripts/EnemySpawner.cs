using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] enemyPointsSpawns;
    public GameObject enemy;

    private int MaxEnemyOnGround = 2;

    // Use this for initialization
    void Start()
    {
        Spawn();
    } 

    void Spawn()
    {
        HashSet<int> possiblePositions = new HashSet<int>();
        int maxPositions = Math.Min(enemyPointsSpawns.Length, MaxEnemyOnGround);
        for (int i = 0; i < maxPositions; i++)
        {
            possiblePositions.Add(i);
        }

        System.Random random = new System.Random();

        for (int i = 0; i < maxPositions; i++)
        {
            int randomPosition = possiblePositions.ElementAt(random.Next(possiblePositions.Count));
            possiblePositions.Remove(randomPosition);

            Transform enemyPosition = enemyPointsSpawns[randomPosition];
            Instantiate(enemy, enemyPosition.position, Quaternion.identity);
        }
    }
}