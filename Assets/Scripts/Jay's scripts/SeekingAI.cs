using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingAI : MonoBehaviour
{
    // THIS SCRIPT GOES ON SEEKING AI

    private PlayerGridMovement PlayerGridMovement;

    [HideInInspector]
    public bool enemyHasMoved;

    public LayerMask whatStopsMovement;

    public Transform player;

    void Awake()
    {
        PlayerGridMovement = GameObject.Find("Pupple - Player").GetComponent<PlayerGridMovement>();
        player = GameObject.Find("Pupple - Player").transform;
    }


    void Start()
    {
        enemyHasMoved = false;
    }


    void Update()
    {
        if (PlayerGridMovement.counter == 0)
        {
            enemyHasMoved = false;
        }

        if (PlayerGridMovement.counter == 2)
        {
            if (enemyHasMoved == false)
            {
                /////////////////
                // AI MOVEMENT //
                /////////////////

                /* ********************************
                 * ********************************
                 * ********************************
                 * ********************************
                 * IF X AXES ARE CLOSER THAN Y AXES
                 * ********************************
                 * ********************************
                 * ********************************
                 * ********************************
                */
                if ((Mathf.Abs(transform.position.x - player.position.x)) < (Mathf.Abs(transform.position.y - player.position.y)))
                {
                    // if moving up is closer
                    if ((Mathf.Abs((transform.position.y + 1) - player.position.y)) < (Mathf.Abs((transform.position.y - 1) - player.position.y)))
                    {
                        // check if moving into dead end
                        if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, 2f, 0f), 0.2f, whatStopsMovement) &&
                            (Physics2D.OverlapCircle(transform.position + new Vector3(1f, 1f, 0f), 0.2f, whatStopsMovement)) &&
                            (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 1f, 0f), 0.2f, whatStopsMovement)))
                        {
                            // move right if it's closer
                            if ((Mathf.Abs((transform.position.x + 1) - player.position.x)) < (Mathf.Abs((transform.position.x - 1) - player.position.x)))
                            {
                                // check left
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x + 1, transform.position.y, -2);
                                }
                                // check right
                                else if (Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                                }
                            }
                            // move left if it's closer
                            else if ((Mathf.Abs((transform.position.x - 1) - player.position.x)) < (Mathf.Abs((transform.position.x + 1) - player.position.x)))
                            {
                                // check left
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x + 1, transform.position.y, -2);
                                }
                                // check right
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                                }
                            }
                            // move left/right if available
                            else if ((Mathf.Abs((transform.position.x - 1) - player.position.x)) == (Mathf.Abs((transform.position.x + 1) - player.position.x)) ||
                                ((Mathf.Abs((transform.position.x - 1) - player.position.x)) == (Mathf.Abs((transform.position.x + 1) - player.position.x))))
                            {
                                // if collider to left and nothing to right
                                // move right
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement) &&
                                    !Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x + 1, transform.position.y, -2);
                                }
                                // if collider to right and nothing to left
                                // move left
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement) &&
                                    !Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                                }
                            }
                        }
                        // move if there's no collidables
                        else if (!Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement))
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y + 1, -2);
                        }
                        // move left/right if there is a collidable above
                        else if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement))
                        {
                            // move left if there's a collidable to the right
                            if (Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement))
                            {
                                transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                            }
                            // move right if there's a collidable to the left
                            else if (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement))
                            {
                                transform.position = new Vector3(transform.position.x + 1, transform.position.y, -2);
                            }
                            // if there are no collidables left and right
                            else if (!Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement) &&
                                     !Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement))
                            {
                                // move left if x axes of player and AI are equal
                                if (transform.position.x == player.position.x)
                                {
                                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                                }
                                // move right if it's closer
                                else if ((Mathf.Abs((transform.position.x + 1) - player.position.x)) < (Mathf.Abs((transform.position.x - 1) - player.position.x)))
                                {
                                    transform.position = new Vector3(transform.position.x + 1, transform.position.y, -2);
                                }
                                // move left if it's closer
                                else if ((Mathf.Abs((transform.position.x - 1) - player.position.x)) < (Mathf.Abs((transform.position.x + 1) - player.position.x)))
                                {
                                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                                }
                            }
                        }
                    }
                    // if moving down is closer
                    else if ((Mathf.Abs((transform.position.y - 1) - player.position.y)) < (Mathf.Abs((transform.position.y + 1) - player.position.y)))
                    {
                        // check if moving into dead end
                        if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, -2f, 0f), 0.2f, whatStopsMovement) &&
                            (Physics2D.OverlapCircle(transform.position + new Vector3(1f, -1f, 0f), 0.2f, whatStopsMovement)) &&
                            (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, -1f, 0f), 0.2f, whatStopsMovement)))
                        {
                            // move right if it's closer
                            if ((Mathf.Abs((transform.position.x + 1) - player.position.x)) < (Mathf.Abs((transform.position.x - 1) - player.position.x)))
                            {
                                // check left
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x + 1, transform.position.y, -2);
                                }
                                // check right
                                else if (Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                                }
                            }
                            // move left if it's closer
                            else if ((Mathf.Abs((transform.position.x - 1) - player.position.x)) < (Mathf.Abs((transform.position.x + 1) - player.position.x)))
                            {
                                // check left
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x + 1, transform.position.y, -2);
                                }
                                // check right
                                else if (Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                                }
                            }
                            // move left/right if available
                            else if ((Mathf.Abs((transform.position.x - 1) - player.position.x)) == (Mathf.Abs((transform.position.x + 1) - player.position.x)) ||
                                ((Mathf.Abs((transform.position.x - 1) - player.position.x)) == (Mathf.Abs((transform.position.x + 1) - player.position.x))))
                            {
                                // if collider to left and nothing to right
                                // move right
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement) &&
                                    !Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x + 1, transform.position.y, -2);
                                }
                                // if collider to right and nothing to left
                                // move left
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement) &&
                                    !Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                                }
                            }
                        }
                        // move if there's no collidables
                        if (!Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement))
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y - 1, -2);
                        }
                        // move left/right if there is a collidable below
                        else if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement))
                        {
                            // move left if there's a collidable to the right
                            if (Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement))
                            {
                                transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                            }
                            // move right if there's a collidable to the left
                            else if (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement))
                            {
                                transform.position = new Vector3(transform.position.x + 1, transform.position.y, -2);
                            }
                            // if there are no collidables left and right
                            else if (!Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement) &&
                                     !Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement))
                            {
                                // move left if x axes of player and AI are equal
                                if (transform.position.x == player.position.x)
                                {
                                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                                }
                                // move right if it's closer
                                else if ((Mathf.Abs((transform.position.x + 1) - player.position.x)) < (Mathf.Abs((transform.position.x - 1) - player.position.x)))
                                {
                                    transform.position = new Vector3(transform.position.x + 1, transform.position.y, -2);
                                }
                                // move left if it's closer
                                else if ((Mathf.Abs((transform.position.x - 1) - player.position.x)) < (Mathf.Abs((transform.position.x + 1) - player.position.x)))
                                {
                                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                                }
                            }
                        }
                    }
                }
                /* ********************************
                 * ********************************
                 * ********************************
                 * ********************************
                 * IF Y AXES ARE CLOSER THAN X AXES
                 * ********************************
                 * ********************************
                 * ********************************
                 * ********************************
                */
                else if ((Mathf.Abs(transform.position.y - player.position.y)) < (Mathf.Abs(transform.position.x - player.position.x)))
                {
                    // if moving right is closer
                    if ((Mathf.Abs((transform.position.x + 1) - player.position.x)) < (Mathf.Abs((transform.position.x - 1) - player.position.x)))
                    {
                        // check if moving into dead end
                        if (Physics2D.OverlapCircle(transform.position + new Vector3(2f, 0f, 0f), 0.2f, whatStopsMovement) &&
                            (Physics2D.OverlapCircle(transform.position + new Vector3(1f, 1f, 0f), 0.2f, whatStopsMovement)) &&
                            (Physics2D.OverlapCircle(transform.position + new Vector3(1f, -1f, 0f), 0.2f, whatStopsMovement)))
                        {
                            // move up if it's closer
                            if ((Mathf.Abs((transform.position.y + 1) - player.position.y)) < (Mathf.Abs((transform.position.y - 1) - player.position.y)))
                            {
                                // check up
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y - 1, -2);
                                }
                                // check down
                                else if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, -2);
                                }
                            }
                            // move down if it's closer
                            else if ((Mathf.Abs((transform.position.y - 1) - player.position.y)) < (Mathf.Abs((transform.position.y + 1) - player.position.y)))
                            {
                                // check up
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y - 1, -2);
                                }
                                // check down
                                else if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, -2);
                                }
                            }
                            // move up/down if available
                            else if ((Mathf.Abs((transform.position.y - 1) - player.position.y)) == (Mathf.Abs((transform.position.y + 1) - player.position.y)) ||
                                ((Mathf.Abs((transform.position.y - 1) - player.position.y)) == (Mathf.Abs((transform.position.y + 1) - player.position.y))))
                            {
                                // check up
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement) &&
                                    !Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y - 1, -2);
                                }
                                // check down
                                else if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, -2);
                                }
                            }
                        }
                        // move if there's no collidables
                        if (!Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement))
                        {
                            transform.position = new Vector3(transform.position.x + 1, transform.position.y, -2);
                        }
                        // move up/down if there is a collidable right
                        else if (Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.2f, whatStopsMovement))
                        {
                            // move down if there's a collidable above
                            if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement))
                            {
                                transform.position = new Vector3(transform.position.x, transform.position.y - 1, -2);
                            }
                            // move up if there's a collidable below
                            else if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement))
                            {
                                transform.position = new Vector3(transform.position.x, transform.position.y + 1, -2);
                            }
                            // if there are no collidables above and below
                            else if (!Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement) &&
                                     !Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement))
                            {
                                // move down if y axes of player and AI are equal
                                if (transform.position.y == player.position.y)
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y - 1, -2);
                                }
                                // move up if it's closer
                                else if ((Mathf.Abs((transform.position.y + 1) - player.position.y)) < (Mathf.Abs((transform.position.y - 1) - player.position.y)))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, -2);
                                }
                                // move down if it's closer
                                else if ((Mathf.Abs((transform.position.y - 1) - player.position.y)) < (Mathf.Abs((transform.position.y + 1) - player.position.y)))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y - 1, -2);
                                }
                            }
                        }
                    }
                    // if moving left is closer
                    else if ((Mathf.Abs((transform.position.x - 1) - player.position.x)) < (Mathf.Abs((transform.position.x + 1) - player.position.x)))
                    {
                        // check if moving into dead end
                        if (Physics2D.OverlapCircle(transform.position + new Vector3(-2f, 0f, 0f), 0.2f, whatStopsMovement) &&
                            (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 1f, 0f), 0.2f, whatStopsMovement)) &&
                            (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, -1f, 0f), 0.2f, whatStopsMovement)))
                        {
                            // move up if it's closer
                            if ((Mathf.Abs((transform.position.y + 1) - player.position.y)) < (Mathf.Abs((transform.position.y - 1) - player.position.y)))
                            {
                                // check up
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y - 1, -2);
                                }
                                // check down
                                else if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, -2);
                                }
                            }
                            // move down if it's closer
                            else if ((Mathf.Abs((transform.position.y - 1) - player.position.y)) < (Mathf.Abs((transform.position.y + 1) - player.position.y)))
                            {
                                // check up
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y - 1, -2);
                                }
                                // check down
                                else if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, -2);
                                }
                            }
                            // move left/right if available
                            else if ((Mathf.Abs((transform.position.y - 1) - player.position.y)) == (Mathf.Abs((transform.position.y + 1) - player.position.y)) ||
                                ((Mathf.Abs((transform.position.y - 1) - player.position.y)) == (Mathf.Abs((transform.position.y + 1) - player.position.y))))
                            {
                                // check up
                                if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y - 1, -2);
                                }
                                // check down
                                else if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, -2);
                                }
                            }
                        }
                        // move if there's no collidables
                        if (!Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement))
                        {
                            transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                        }
                        // move up/down if there is a collidable left
                        else if (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.2f, whatStopsMovement))
                        {
                            // move down if there's a collidable above
                            if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement))
                            {
                                transform.position = new Vector3(transform.position.x, transform.position.y - 1, -2);
                            }
                            // move up if there's a collidable below
                            else if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement))
                            {
                                transform.position = new Vector3(transform.position.x, transform.position.y + 1, -2);
                            }
                            // if there are no collidables above and below
                            else if (!Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.2f, whatStopsMovement) &&
                                     !Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), 0.2f, whatStopsMovement))
                            {
                                // move down if y axes of player and AI are equal
                                if (transform.position.y == player.position.y)
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y - 1, -2);
                                }
                                // move up if it's closer
                                else if ((Mathf.Abs((transform.position.y + 1) - player.position.y)) < (Mathf.Abs((transform.position.y - 1) - player.position.y)))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, -2);
                                }
                                // move down if it's closer
                                else if ((Mathf.Abs((transform.position.y - 1) - player.position.y)) < (Mathf.Abs((transform.position.y + 1) - player.position.y)))
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y - 1, -2);
                                }
                            }
                        }
                    }
                }
                // if distance between x and y axes are equal
                else if ((Mathf.Abs(transform.position.y - player.position.y)) == (Mathf.Abs(transform.position.x - player.position.x)))
                {
                    // HAVE TO IMPLEMENT COLLIDABLES
                    if (player.position.x > transform.position.x)
                    {
                        transform.position = new Vector3(transform.position.x + 1, transform.position.y, -2);
                    }
                    else if (player.position.x < transform.position.x)
                    {
                        transform.position = new Vector3(transform.position.x - 1, transform.position.y, -2);
                    }
                }
            }
            enemyHasMoved = true;
        }
    }
}
