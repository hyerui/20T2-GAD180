using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SophiaCountdownTimer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    public GameObject lossText;

    private void Start()
    {
        //Starts timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                //Timer runs
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                lossText.SetActive(false);
            }
            else
            {
                //Timer hits zero
                Debug.Log("Time's Up!");
                timeRemaining = 0;
                timerIsRunning = false;
                lossText.SetActive(true);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }
    void DisplayTime(float timeToDisplay) //To display minutes and seconds in Unity
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds); // ':' within the {} seperates the reference number from the value's format. 0 is for minutes, 1 is for seconds

        //Add if you want milliseconds and comment out the above timeText.Text line
        //float milliseconds = (timeToDisplay % 1) * 1000;
        //timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
