using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordObjective : MonoBehaviour
{
    // THIS SCRIPT GOES ON PLAYER

    public Transform[] resetBlocks;
    public Transform player;

    public Transform wordAPos;
    public Transform wordBPos;
    public Transform wordCPos;

    public Transform wordADestination;
    public Transform wordBDestination;
    public Transform wordCDestination;

    public Transform wordASpawn;
    public Transform wordBSpawn;
    public Transform wordCSpawn;

    // bools for if word is picked up
    public bool wordAPickedUp;
    public bool wordBPickedUp;
    public bool wordCPickedUp;

    // bools for if word is complete
    private bool wordAComplete;
    private bool wordBComplete;
    private bool wordCComplete;

    public GameObject victoryScreenUI;

    public bool gameIsWon;
    public bool wordIsHeld;

    public Animator animWordA;
    public Animator animWordB;
    public Animator animWordC;

    public GameObject wordA;
    public GameObject wordB;
    public GameObject wordC;

    public Animator animPlayer;

    private Vector3 scaleChange;

    private PlayerGridMovement PlayerGridMovement;

    void Awake()
    {
        scaleChange = new Vector3(-0.01f, -0.01f, 0f);
        PlayerGridMovement = GetComponent<PlayerGridMovement>();
    }

    void Start()
    {
        wordAPickedUp = false;
        wordBPickedUp = false;
        wordCPickedUp = false;
        wordAComplete = false;
        wordBComplete = false;
        wordCComplete = false;
        gameIsWon = false;
        wordIsHeld = false;
    }

    void Update()
    {
        // if 1 step away from wordA, press space to pick up
        if (Vector2.Distance(transform.position, wordAPos.position) <= 1.0f &&
            wordAPickedUp == false &&
            wordAComplete == false &&
            wordIsHeld == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                wordAPickedUp = true;
                wordIsHeld = true;
            }
        }

        // if 1 unit away from wordA destination tile, press space to place
        // wordA complete
        if (Vector2.Distance(transform.position, wordADestination.position) < 1.2f &&
            wordAPickedUp == true &&
            wordIsHeld == true &&
            PlayerGridMovement.isMoving == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                wordAPickedUp = false;
                wordAComplete = true;
                wordIsHeld = false;
            }
        }

        // if bool is true, wordA follows player
        if (wordAPickedUp == true)
        {
            wordAPos.position = Vector2.MoveTowards(wordAPos.position, new Vector2(transform.position.x, transform.position.y + 0.3f), (10.0f * Time.deltaTime));
            animWordA.SetBool("Holding", true);
            if (wordA.transform.localScale.y > 0.84f &&
                wordA.transform.localScale.x > 0.84f)
            {
                wordA.transform.localScale += scaleChange;
            }
        }
        if (wordAPickedUp == false)
        {
            animWordA.SetBool("Holding", false);
            if (wordA.transform.localScale.y < 1.0f &&
                wordA.transform.localScale.x < 1.0f)
            {
                wordA.transform.localScale -= scaleChange;
            }
        }
        
        // SAME AS ABOVE FOR WORD B
        if (Vector2.Distance(transform.position, wordBPos.position) <= 1.0f &&
            wordBPickedUp == false &&
            wordBComplete == false &&
            wordIsHeld == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                wordBPickedUp = true;
                wordIsHeld = true;
            }
        }
        if (Vector2.Distance(transform.position, wordBDestination.position) < 1.2f &&
            wordBPickedUp == true &&
            wordIsHeld == true &&
            PlayerGridMovement.isMoving == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                wordBPickedUp = false;
                wordBComplete = true;
                wordIsHeld = false;
            }
        }
        if (wordBPickedUp == true)
        {
            wordBPos.position = Vector2.MoveTowards(wordBPos.position, new Vector2(transform.position.x, transform.position.y + 0.3f), (10.0f * Time.deltaTime));
            animWordB.SetBool("Holding", true);
            if (wordB.transform.localScale.y > 0.84f &&
                wordB.transform.localScale.x > 0.84f)
            {
                wordB.transform.localScale += scaleChange;
            }
        }
        if (wordBPickedUp == false)
        {
            animWordB.SetBool("Holding", false);
            if (wordB.transform.localScale.y < 1.0F &&
                wordB.transform.localScale.x < 1.0f)
            {
                wordB.transform.localScale -= scaleChange;
            }
        }

        // SAME AS ABOVE FOR WORD C
        if (Vector2.Distance(transform.position, wordCPos.position) <= 1.0f &&
            wordCPickedUp == false &&
            wordCComplete == false &&
            wordIsHeld == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                wordCPickedUp = true;
                wordIsHeld = true;
            }
        }
        if (Vector2.Distance(transform.position, wordCDestination.position) < 1.2f &&
            wordCPickedUp == true &&
            wordIsHeld == true &&
            PlayerGridMovement.isMoving == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                wordCPickedUp = false;
                wordCComplete = true;
                wordIsHeld = false;
            }
        }
        if (wordCPickedUp == true)
        {
            wordCPos.position = Vector2.MoveTowards(wordCPos.position, new Vector2(transform.position.x, transform.position.y + 0.3f), (10.0f * Time.deltaTime));
            animWordC.SetBool("Holding", true);
            if (wordC.transform.localScale.y > 0.84f &&
                wordC.transform.localScale.x > 0.84f)
            {
                wordC.transform.localScale += scaleChange;
            }
        }
        if (wordCPickedUp == false)
        {
            animWordC.SetBool("Holding", false);
            if (wordC.transform.localScale.y < 1.0f &&
                wordC.transform.localScale.x < 1.0f)
            {
                wordC.transform.localScale -= scaleChange;
            }
        }


        // set position of words to be above pupple when picked up
        if (wordAPickedUp == true)
        {
            wordAPos.position = new Vector3(wordAPos.position.x, (wordAPos.position.y), -2);
        }
        if (wordBPickedUp == true)
        {
            wordBPos.position = new Vector3(wordBPos.position.x, wordBPos.position.y, -2);
        }
        if (wordCPickedUp == true)
        {
            wordCPos.position = new Vector3(wordCPos.position.x, wordCPos.position.y, -2);
        }

        // move words to word destination tiles when complete
        if (wordAComplete)
        {
            wordAPos.position = Vector3.MoveTowards(wordAPos.position, (new Vector3(wordADestination.position.x, wordADestination.position.y, -3)), (10.0f * Time.deltaTime));
        }
        if (wordBComplete)
        {
            wordBPos.position = Vector3.MoveTowards(wordBPos.position, (new Vector3(wordBDestination.position.x, wordBDestination.position.y, -3)), (10.0f * Time.deltaTime));
        }
        if (wordCComplete)
        {
            wordCPos.position = Vector3.MoveTowards(wordCPos.position, (new Vector3(wordCDestination.position.x, wordCDestination.position.y, -3)), (10.0f * Time.deltaTime));
        }

        // if all words are complete, win game
        if (wordAComplete == true &&
            wordBComplete == true &&
            wordCComplete == true &&
            Vector2.Distance(wordAPos.position, wordADestination.position) == 0.0f &&
            Vector2.Distance(wordBPos.position, wordBDestination.position) == 0.0f &&
            Vector2.Distance(wordCPos.position, wordCDestination.position) == 0.0f)
        {
            gameIsWon = true;
        }
        
        // animation if word is held
        if (wordIsHeld == true)
        {
            animPlayer.SetBool("isCarrying", true);
        }
        if (wordIsHeld == false)
        {
            animPlayer.SetBool("isCarrying", false);
        }

        // activate ui if game has been won
        if (gameIsWon == false)
        {
            victoryScreenUI.SetActive(false);
        } else
        if (gameIsWon == true)
        {
            victoryScreenUI.SetActive(true);
        }



        // reset block
        for (int i = 0; i < resetBlocks.Length; ++i)
        {
            if (Vector2.Distance(player.position, resetBlocks[i].position) < 0.2f)
            {
                if (wordAPickedUp == true &&
                    wordIsHeld == true)
                {
                    wordAPickedUp = false;
                    wordIsHeld = false;
                }
                if (wordBPickedUp == true &&
                    wordIsHeld == true)
                {
                    wordBPickedUp = false;
                    wordIsHeld = false;
                }
                if (wordCPickedUp == true &&
                    wordIsHeld == true)
                {
                    wordCPickedUp = false;
                    wordIsHeld = false;
                }
            }
            if (wordAPickedUp == false &&
                wordIsHeld == false &&
                wordAComplete == false)
            {
                wordAPos.position = Vector2.MoveTowards(wordAPos.position, new Vector2(wordASpawn.position.x, wordASpawn.position.y), (50.0f * Time.deltaTime));
            }
            if (wordBPickedUp == false &&
                wordIsHeld == false &&
                wordBComplete == false)
            {
                wordBPos.position = Vector2.MoveTowards(wordBPos.position, new Vector2(wordBSpawn.position.x, wordBSpawn.position.y), (50.0f * Time.deltaTime));
            }
            if (wordCPickedUp == false &&
                wordIsHeld == false &&
                wordCComplete == false)
            {
                wordCPos.position = Vector2.MoveTowards(wordCPos.position, new Vector2(wordCSpawn.position.x, wordCSpawn.position.y), (50.0f * Time.deltaTime));
            }
        }
    }
}
