﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndfGame : MonoBehaviour
{
    private int allCoins = 0;
    public TextMeshProUGUI endOfGameText;

    private int pickupedCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        endOfGameText.text = "";
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int coinsToWin = (allCoins * 80) / 100;
            if (pickupedCoins >= coinsToWin)
            {
                endOfGameText.text = "You won";
                Destroy(other.gameObject.GetComponent<Controller>());
                Destroy(other.gameObject.GetComponent<PickupCoin>());
                Destroy(Camera.main.GetComponent<CameraFollower>());
                ActivateMe();
            }
            else
            {
                endOfGameText.text = "You need to pickup " + coinsToWin.ToString();
                DeactivateMe();
            }
        }
    }

    public void ActivateMe()
    {
        endOfGameText.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DeactivateMe()
    {
        StartCoroutine(RemoveAfterSeconds(3));
    }

    IEnumerator RemoveAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        endOfGameText.gameObject.SetActive(false);
    }

    public void UpdateCoins(int pickuped)
    {
        this.pickupedCoins = pickuped;
    }

    public void setCoins(int all)
    {
        this.allCoins += all;
    }
}