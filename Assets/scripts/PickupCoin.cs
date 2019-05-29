using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    private int _countCoin;
    private EndfGame endfGame;
    public TextMeshProUGUI countText;
    // Start is called before the first frame update
    void Start()
    {
        
       
        _countCoin = 0;
        SetCountText();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        endfGame = GameObject.FindObjectOfType<EndfGame>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            _countCoin++;
            Destroy(other.gameObject);
            SetCountText();
            endfGame.UpdateCoins(_countCoin);
        }
    }

   private void SetCountText()
    {
        countText.text = "Coins:" + _countCoin.ToString();
    }

}
