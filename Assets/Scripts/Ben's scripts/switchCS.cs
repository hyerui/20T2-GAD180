using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCS : MonoBehaviour
{

    public static float currenttime = 20f;



    void Start()
    {
        gameObject.layer = 0;
    }


    void Update()
    {
        currenttime -= Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
