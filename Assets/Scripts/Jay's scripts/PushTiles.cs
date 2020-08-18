using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushTiles : MonoBehaviour
{
    // THIS SCRIPT GOES ON ARROW TILES
    
    public float tilesToPush;

    public bool pushUp;
    public bool pushDown;
    public bool pushLeft;
    public bool pushRight;

    public Transform movePoint;
    public Transform player;

    public Animator animPlayer;

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < 0.2f &&
            pushUp == true)
        {
            animPlayer.SetBool("isSliding", true);
            animPlayer.SetFloat("Sliding", -1f);
            movePoint.SetPositionAndRotation(new Vector3(transform.position.x, (transform.position.y + tilesToPush), movePoint.position.z), Quaternion.identity);
        }
        if (Vector2.Distance(transform.position, player.position) < 0.2f &&
            pushDown == true)
        {
            animPlayer.SetBool("isSliding", true);
            animPlayer.SetFloat("Sliding", 1f);
            movePoint.SetPositionAndRotation(new Vector3(transform.position.x, (transform.position.y - tilesToPush), movePoint.position.z), Quaternion.identity);
        }
        if (Vector2.Distance(transform.position, player.position) < 0.2f &&
            pushLeft == true)
        {
            animPlayer.SetBool("isSliding", true);
            animPlayer.SetFloat("Sliding", -1f);
            movePoint.SetPositionAndRotation(new Vector3((transform.position.x - tilesToPush), transform.position.y, movePoint.position.z), Quaternion.identity);
        }
        if (Vector2.Distance(transform.position, player.position) < 0.2f &&
            pushRight == true)
        {
            animPlayer.SetBool("isSliding", true);
            animPlayer.SetFloat("Sliding", 1f);
            movePoint.SetPositionAndRotation(new Vector3((transform.position.x + tilesToPush), transform.position.y, movePoint.position.z), Quaternion.identity);
        }

        if (Vector2.Distance(movePoint.position, player.position) < 0.2f)
        {
            animPlayer.SetBool("isSliding", false);
        }
    }
}
