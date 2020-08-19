using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacingAI : MonoBehaviour
{
    // THIS GOES ON WANDERING AI

    public float x1;
    public float x2;
    public float y1;
    public float y2;

    private bool atDes1;
    private bool atDes2;

    void Update()
    {
        if (x1 * x2 == 0)
        {
            // change bool values
            // based on AI position
            if (transform.position.y == y1)
            {
                atDes1 = true;
                atDes2 = false;
            }

            if (transform.position.y == y2)
            {
                atDes2 = true;
                atDes1 = false;
            }

            // pace between two given y-coords
            if (atDes1 == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, y2, -2), (2f * Time.deltaTime));
            }
            if (atDes2 == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, y1, -2), (2f * Time.deltaTime));
            }
        }

        if (y1 * y2 == 0)
        {
            // change bool values
            // based on AI position
            if (transform.position.x == x1)
            {
                atDes1 = true;
                atDes2 = false;
            }

            if (transform.position.x == x2)
            {
                atDes2 = true;
                atDes1 = false;
            }

            // pace between two given y-coords
            if (atDes1 == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(x2, transform.position.y), (2f * Time.deltaTime));
            }
            if (atDes2 == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(x1, transform.position.y), (2f * Time.deltaTime));
            }
        }
    }
}
