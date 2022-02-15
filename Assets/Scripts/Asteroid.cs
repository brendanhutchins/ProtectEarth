using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 100f;

    private Transform target;

    private void Awake()
    {
        float xPos;
        float yPos;

        // Random xPos
        float xMin = Random.Range(-10, -7);
        float xMax = Random.Range(7, 10);
        if (Random.value < 0.5f)
            xPos = xMin;
        else
            xPos = xMax;

        yPos = Random.Range(-5, 5);

        transform.position = new Vector3(xPos, yPos, 0.0f);
        target = GameObject.Find("Earth").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(Hulk(0.3f));
    }

    IEnumerator Hulk(float delay)
    {
        yield return new WaitForSeconds(delay);
        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        while (true)
        {
            float step = speed * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            for (float duration = 1f; duration > 0; duration -= Time.fixedDeltaTime)
            {
                yield return waitForFixedUpdate;
            }
        }
    }
}
