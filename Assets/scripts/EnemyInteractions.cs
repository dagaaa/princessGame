using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyInteractions : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI ghostsText;

    public int lives = 3;
    private int _killedGhosts = 0;

    void Start()
    {
        setLivesText();
        setGhostsText();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyTop"))
        {
            Destroy(other.transform.parent.gameObject);
            _killedGhosts++;
            setGhostsText();
        }
        else if (other.gameObject.CompareTag("EnemySide"))
        {
            if (--lives <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                var position = transform.position;
                transform.position = new Vector3(position.x, position.y + 10f, position.z);
            }
            setLivesText();
        }
    }

    private void setLivesText()
    {
        livesText.text = "Lives:" + lives;
    }

    private void setGhostsText()
    {
        ghostsText.text = "Killed:" + _killedGhosts;
    }
}
