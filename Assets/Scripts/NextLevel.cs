using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // THIS GOES ON GAME CANVAS

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(3);
    }


}
