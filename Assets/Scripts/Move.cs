using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class Move : MonoBehaviour
{
    public static SerialPort serial = new SerialPort("COM3", 9600);

    private float calcInput = 0f;
    private float margin = 0.05f;
    private float speed = 150f;
    private float factor = 7f;
    private float currentInput = 0f;
    private int ii = 0;

    private void Start()
    {
        if (serial != null)
        {
            if (!serial.IsOpen)
            {
                serial.Open();
                //serial.ReadTimeout = 16; //give refresh rate of 60.5 fps
            }
        }
        //ii = 0;
        //serial.Write(ii.ToString());
    }

    private void Update()
    {
        currentInput = int.Parse(serial.ReadLine()) * factor;

        // Use this block for linear increase or decrease
        if (calcInput < currentInput - margin)
        {
            calcInput += Time.deltaTime * speed;
        }
        else if (calcInput > currentInput + margin)
        {
            calcInput -= Time.deltaTime * speed;
        }
        else // calcInput is very close to currentInput so we are ready to update currentInput
        {
            // Get input from arduino
            currentInput = float.Parse(serial.ReadLine()) * factor;
            //print("Arduino input: " + currentInput);
        }
        //print("Calculated input: " + calcInput);
        transform.localEulerAngles = new Vector3(0, 0, calcInput);
    }

    private void OnApplicationQuit()
    {
        ii = 1;
        serial.Write(ii.ToString());
        serial.Close();
    }

}
