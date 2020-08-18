using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PersistentTimer : MonoBehaviour
{
    static DateTime TimeStarted;
    static TimeSpan TotalTime;

    // Start is called before the first frame update
    public static void StartCountDown(TimeSpan totalTime)
    {
        TimeStarted = DateTime.UtcNow;
        TotalTime = totalTime;
    }

    public static TimeSpan Timeleft
    {
        get
        {
            var result = TotalTime - (DateTime.UtcNow - TimeStarted);
            if (result.TotalSeconds <= 0)
            {
                return TimeSpan.Zero;
            }
            return result;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
