using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptTesting : MonoBehaviour
{
    public double[] nCharacters;
    public double total;
    public double average;
    public Text test;
    public Text perfectTest;
    public int perfectInt;

    // Start is called before the first frame update
    void Start()
    {
        averageMethod();
        percentPerfect();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void averageMethod()
    {
        total = 0;
        for (int i = 0; i < nCharacters.Length; ++i)
        {
            total = total + nCharacters[i];
        }
        average = (total / nCharacters.Length);
        test.text = average.ToString();
    }

    public void percentPerfect()
    {
        for (int i = 0; i < nCharacters.Length; ++i)
        {
            if (nCharacters[i] == 10)
            {
                perfectInt += 1;
            }
        }
        perfectTest.text = perfectInt.ToString();
    }

    public void averageCounter()
    {
        
    }
}
