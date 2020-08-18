﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersistentCounter : MonoBehaviour
{
    public Text timeText;
    public GameObject lossText;
    public float losstime = 3;
    private WordObjective WordObjective;

    void Awake()
    {
        //Connects word objective script, to stop timer when win is achieved
        WordObjective = GameObject.Find("Pupple - Player").GetComponent<WordObjective>();
    }

    void Update()
    {
        DisplayTime();

        if (GlobalCountDown.TimeLeft.Seconds > 0)
        {
            lossText.SetActive(false);
        }

        // if timer hits 0
        // show losstimer text
        // disable player movement
        if (GlobalCountDown.TimeLeft.Seconds <= 0)
        {
            lossText.SetActive(true);
            losstime -= Time.deltaTime;
            GameObject.Find("Pupple - Player").GetComponent<PlayerGridMovement>().enabled = false;

            // reset scene after delay
            if (losstime <= 0)
            {
                Debug.Log("reset");
                GlobalCountDown.StartCountDown(System.TimeSpan.FromSeconds(10));
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        //Reset Function
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void DisplayTime() //To display minutes and seconds in Unity
    {
        timeText.text = GlobalCountDown.TimeLeft.ToString(@"m\:ss");
    }
}