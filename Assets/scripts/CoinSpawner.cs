using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public Transform[] coinSpawns;
    public GameObject coin;
    private EndfGame endfGame;
    

    // Use this for initialization
    void Start () {

        Spawn();
    }
    void Awake()
    {
        endfGame = GameObject.FindObjectOfType<EndfGame>();
    }
    void Spawn()
    {
        int allCoins = 0;
        for (int i = 0; i < coinSpawns.Length; i++)
        {
            int coinFlip = Random.Range (0, 2);
            if (coinFlip > 0)
            {
                allCoins++;
                Instantiate(coin, coinSpawns[i].position, Quaternion.identity);
            }
        }
        endfGame.setCoins(allCoins);
    }
}
