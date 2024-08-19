using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTXT;
    [SerializeField] SoundManager soundManager;
    int score;
    int scoreByTen;
    [SerializeField] ParticleSystem playerPS;

    [SerializeField] GameManager gameManager;
    [SerializeField] PlatformSpawner platformSpawner;

    void Start()
    {
        score = 0;
        scoreByTen = 10;
        scoreTXT.text = "Gems: " + score.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            score++;
            scoreTXT.text = "Gems: " + score.ToString();
            playerPS.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {

            Time.timeScale = 0.3f;
            gameManager.EnableGameOverCanvas();
            soundManager.PlayLossingSoundEffect();
            platformSpawner.enabled = false;
            Destroy(gameObject);
        }
    }

}
