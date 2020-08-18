using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // THIS GOES ON GAME CANVAS

    // load level two
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene(4);
    }

}
