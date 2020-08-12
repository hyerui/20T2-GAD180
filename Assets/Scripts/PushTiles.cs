using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < 0.2f &&
            pushUp == true)
        {
            movePoint.SetPositionAndRotation(new Vector3(transform.position.x, (transform.position.y + tilesToPush), movePoint.position.z), Quaternion.identity);
        }
        if (Vector2.Distance(transform.position, player.position) < 0.2f &&
            pushDown == true)
        {
            movePoint.SetPositionAndRotation(new Vector3(transform.position.x, (transform.position.y - tilesToPush), movePoint.position.z), Quaternion.identity);
        }
        if (Vector2.Distance(transform.position, player.position) < 0.2f &&
            pushLeft == true)
        {
            movePoint.SetPositionAndRotation(new Vector3((transform.position.x - tilesToPush), transform.position.y, movePoint.position.z), Quaternion.identity);
        }
        if (Vector2.Distance(transform.position, player.position) < 0.2f &&
            pushRight == true)
        {
            movePoint.SetPositionAndRotation(new Vector3((transform.position.x + tilesToPush), transform.position.y, movePoint.position.z), Quaternion.identity);
        }
    }
}
