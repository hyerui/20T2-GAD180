using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public static float currentTime = 10.0f;

    public Text test;

    void Update()
    {
        currentTime -= Time.deltaTime;
        test.text = currentTime.ToString("F0");
    }
}
