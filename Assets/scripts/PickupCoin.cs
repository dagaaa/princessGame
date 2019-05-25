using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    public int countCoin;
    
    public TextMeshProUGUI countText;
    // Start is called before the first frame update
    void Start()
    {
        
       
        countCoin = 0;
        SetCountText();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            countCoin++;
            Destroy(other.gameObject);
            SetCountText();
        }
    }

   private void SetCountText()
    {
        countText.text = "Coins:" + countCoin.ToString();
    }

}
