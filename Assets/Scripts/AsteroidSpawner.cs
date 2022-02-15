using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateAsteroid", 7.0f, Random.Range(2.0f, 3.5f));
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }

    void CreateAsteroid()
    {
        Object.Instantiate(asteroid);
    }
}
