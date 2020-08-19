using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIReset : MonoBehaviour
{
    // THIS GOES ON PLAYER

    public Transform[] enemies;

    private Transform movePoint;
    private Transform spawn;

    private PlayerGridMovement PlayerGridMovement;
    private WordObjective WordObjective;

    void Awake()
    {
        PlayerGridMovement = GetComponent<PlayerGridMovement>();
        WordObjective = GetComponent<WordObjective>();
    }


    void Start()
    {
        spawn = GameObject.Find("PuppleSpawn").transform;
        movePoint = GameObject.Find("MovePoint").transform;
    }

    void Update()
    {
        for (int i = 0; i < enemies.Length; ++i)
        {
            if (Vector2.Distance(transform.position, enemies[i].position) <= 0.6f)
            {
                GetComponent<PlayerGridMovement>().enabled = false;
                movePoint.position = spawn.position;
                transform.position = spawn.position;

                if (WordObjective.wordAPickedUp == true &&
                    WordObjective.wordIsHeld == true)
                {
                    WordObjective.wordAPickedUp = false;
                    WordObjective.wordIsHeld = false;
                }
                if (WordObjective.wordBPickedUp == true &&
                    WordObjective.wordIsHeld == true)
                {
                    WordObjective.wordBPickedUp = false;
                    WordObjective.wordIsHeld = false;
                }
                if (WordObjective.wordCPickedUp == true &&
                    WordObjective.wordIsHeld == true)
                {
                    WordObjective.wordCPickedUp = false;
                    WordObjective.wordIsHeld = false;
                }
            }

            if (Vector2.Distance(transform.position, enemies[i].position) > 0.6f)
            {
                GetComponent<PlayerGridMovement>().enabled = true;
            }
        }
    }
}
