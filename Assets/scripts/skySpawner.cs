using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxGrounds = 20;
    public GameObject ground;
    public float width = 10.24f;
    

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
          
        }
    }
}
