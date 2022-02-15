using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public AsteroidSpawner asteroidSpawner;
    public AudioSource bgMusic;
    public AudioSource gameOver;
    public AudioSource hitSource;
    public GameObject gameOverPlane;

    float health = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.SetHealthBarValue(health);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        
        health -= 0.18f;

        hitSource.Play();

        HealthBar.SetHealthBarValue(health);

        if (health <= 0.0f)
        {
            asteroidSpawner.StopSpawning();
            bgMusic.Stop();
            gameOver.Play();
            gameOverPlane.SetActive(true);
        }
    }
}
