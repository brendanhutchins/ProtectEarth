using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.SetHealthBarValue(1);
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.SetHealthBarValue(HealthBar.GetHealthBarValue() - 0.01f);
    }
}
