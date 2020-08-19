using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AphasiaMainMenu : MonoBehaviour
{
    // THIS SCRIPT GOES ON MAIN MENU CANVAS

    public void StartGame()
    {
        SceneManager.LoadScene(2);
        GlobalCountDown.StartCountDown(System.TimeSpan.FromMinutes(2));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void HelpButton()
    {
        SceneManager.LoadScene(1);
    }
}
