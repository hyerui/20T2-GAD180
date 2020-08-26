using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGridMovement : MonoBehaviour
{
    // THIS SCRIPT GOES ON PLAYER

    public float moveSpeed = 5f;

    [HideInInspector]
    public Transform movePoint;
    [HideInInspector]
    public Transform spawn;

    [HideInInspector]
    public Animator animator;

    public LayerMask whatStopsMovement;

    [HideInInspector]
    public bool isMoving;

    [HideInInspector]
    public int counter;

    void Start()
    {
        movePoint.parent = null;
        spawn.parent = null;
        isMoving = false;

        // declare variables
        movePoint = GameObject.Find("MovePoint").transform;
        spawn = GameObject.Find("PuppleSpawn").transform;
        animator = GameObject.Find("Pupple - Player").GetComponent<Animator>();
        counter = 0;
    }

    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, movePoint.position, (moveSpeed * Time.deltaTime * 0.75f));

        if (Vector2.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Input.GetKey(KeyCode.LeftArrow) == true &&
                Input.GetKey(KeyCode.RightArrow) == false &&
                Input.GetKey(KeyCode.UpArrow) == false &&
                Input.GetKey(KeyCode.DownArrow) == false)
            {
                isMoving = true;
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(-1f, 0f, 0f);
                    ++counter;
                }
            }
            else 
            if (Input.GetKey(KeyCode.RightArrow) == true &&
                Input.GetKey(KeyCode.LeftArrow) == false &&
                Input.GetKey(KeyCode.UpArrow) == false &&
                Input.GetKey(KeyCode.DownArrow) == false)
            {
                isMoving = true;
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(1f, 0f, 0f);
                    ++counter;
                }
            }
            else
            if (Input.GetKey(KeyCode.UpArrow) == true &&
                Input.GetKey(KeyCode.DownArrow) == false &&
                Input.GetKey(KeyCode.LeftArrow) == false &&
                Input.GetKey(KeyCode.RightArrow) == false)
            {
                isMoving = true;
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, 1f, 0f);
                    ++counter;
                }
            }
            else
            if (Input.GetKey(KeyCode.DownArrow) == true &&
                Input.GetKey(KeyCode.UpArrow) == false &&
                Input.GetKey(KeyCode.LeftArrow) == false &&
                Input.GetKey(KeyCode.RightArrow) == false)
            {
                isMoving = true;
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, -1f, 0f);
                    ++counter;
                }
            }

            // animations
            if (Input.GetAxisRaw("ArrowsHorizontal") == -1f &&
                Input.GetAxisRaw("ArrowsVertical") == 0f)
            {
                animator.SetFloat("Horizontal", -1);
                animator.SetFloat("Vertical", 0);
            }
            if (Input.GetAxisRaw("ArrowsHorizontal") == 1f &&
                Input.GetAxisRaw("ArrowsVertical") == 0f)
            {
                animator.SetFloat("Horizontal", 1);
                animator.SetFloat("Vertical", 0);
            }
            if (Input.GetAxisRaw("ArrowsVertical") == 1f &&
                Input.GetAxisRaw("ArrowsHorizontal") == 0f)
            {
                animator.SetFloat("Vertical", 1);
                animator.SetFloat("Horizontal", 0);
            }
            if (Input.GetAxisRaw("ArrowsVertical") == -1f &&
                Input.GetAxisRaw("ArrowsHorizontal") == 0f)
            {
                animator.SetFloat("Vertical", -1);
                animator.SetFloat("Horizontal", 0);
            }
        }


        if (Input.GetAxisRaw("ArrowsHorizontal") == 0f &&
            Input.GetAxisRaw("ArrowsVertical") == 0f &&
            Vector2.Distance(transform.position, movePoint.position) < 0.2f)
        {
            isMoving = false;
        }

        // idle animation

        if (movePoint.position.x < transform.position.x)
        {
            animator.SetFloat("Idle Horizontal", -1);
            animator.SetFloat("Idle Vertical", 0);
        }
        if (movePoint.position.x > transform.position.x)
        {
            animator.SetFloat("Idle Horizontal", 1);
            animator.SetFloat("Idle Vertical", 0);
        }
        if (movePoint.position.y > transform.position.y)
        {
            animator.SetFloat("Idle Vertical", 1);
            animator.SetFloat("Idle Horizontal", 0);
        }
        if (movePoint.position.y < transform.position.y)
        {
            animator.SetFloat("Idle Vertical", -1);
            animator.SetFloat("Idle Horizontal", 0);
        }

        if (Vector2.Distance(transform.position, movePoint.position) <= 0.02f)
        {
            animator.SetFloat("Speed", 0);
        }
        else
        {
            animator.SetFloat("Speed", 1);
        }

        if (counter == 3)
        {
            counter = 0;
        }
    }
}
