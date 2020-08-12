using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class collideronstate : MonoBehaviour
{
    public static float currenttime = 20f;
    
    
    public Text time;


    void Update()
    {
        currenttime -= Time.deltaTime;
        time.text = currenttime.ToString("F0");

        if (currenttime <= 0)
        {
            currenttime = 20;

        }

        if (currenttime <= 10)
        {
            gameObject.layer = 8;
        }

        if (currenttime >= 10)
        {
            gameObject.layer = 0;
        }
    }
}
