using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHeldPage : MonoBehaviour
{
    public Transform player;

    public Transform wordASpawn;
    public Transform wordBSpawn;
    public Transform wordCSpawn;

    public Transform wordAPos;
    public Transform wordBPos;
    public Transform wordCPos;

    private WordObjective WordObjective;

    void Awake()
    {
        WordObjective = GetComponent<WordObjective>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) == 0.0f)
        {
            if (WordObjective.wordAPickedUp == true)
            {
                wordAPos.position = wordASpawn.position;
            }
        }
    }
}
