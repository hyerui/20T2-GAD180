using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFollowMovePoint : MonoBehaviour
{

    private PlayerGridMovement PlayerGridMovement;

    void Awake()
    {
        PlayerGridMovement = GetComponent<PlayerGridMovement>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerGridMovement.movePoint.position, (PlayerGridMovement.moveSpeed * Time.deltaTime * 0.75f));
    }
}
