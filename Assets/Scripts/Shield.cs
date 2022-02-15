using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shield : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public AudioSource gameSound;
    private int score;
    
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        score++;
        scoreText.text = score.ToString();
        gameSound.Play();
    }
}
