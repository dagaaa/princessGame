﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour{
    // Start is called before the first frame update
    public int maxGrounds = 20;
    public GameObject ground;
    public float width = 10.24f;
    public GameObject castle;

    private Vector2 originPosition;
    


    void Start () {
        
        originPosition = transform.position;
        Spawn ();

    }

    void Spawn()
    {
        
        for (int i = 0; i < maxGrounds; i++)
        {
            Vector2 nextPosition =  new Vector2 (originPosition.x+width, originPosition.y );
            Instantiate(ground, nextPosition, Quaternion.identity);
            originPosition = nextPosition;
            if (i == maxGrounds - 1)
            {
                castle.transform.position= new Vector3(nextPosition.x,castle.transform.position.y,0);
            }
        }
    }
}
