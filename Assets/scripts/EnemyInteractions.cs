using TMPro;
using UnityEngine;

public class EnemyInteractions : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI ghostsText;
    public TextMeshProUGUI endOfGameText;

    public int lives = 3;
    private int _killedGhosts = 0;

    void Start()
    {
        SetLivesText();
        SetGhostsText();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyTop"))
        {
            Destroy(other.transform.parent.gameObject);
            _killedGhosts++;
            SetGhostsText();
        }
        else if (other.gameObject.CompareTag("EnemySide"))
        {
            if (--lives <= 0)
            {
                ActivateMe();
            }
            else
            {
                var position = transform.position;
                transform.position = new Vector3(position.x, position.y + 10f, position.z);
            }
            SetLivesText();
        }
    }

    private void SetLivesText()
    {
        livesText.text = "Lives:" + lives;
    }

    private void SetGhostsText()
    {
        ghostsText.text = "Killed:" + _killedGhosts;
    }
    
    public void ActivateMe ()
    {
        endOfGameText.text = "YOU LOST!";
        endOfGameText.gameObject.SetActive (true);
        Destroy(gameObject.GetComponent<Controller>());
        Destroy(gameObject.GetComponent<PickupCoin>());
        Destroy(Camera.main.GetComponent<CameraFollower>());
        Destroy(gameObject);
        Time.timeScale = 0f;
    }
}
