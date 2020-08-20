using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class UIAssistant : MonoBehaviour
{ 
    public Text messageText;
    private Text nameText;
    public int check = 0;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Start()
    {

        TextWriting.TextWriter_Static(messageText, "The vague mumbling of voices reach their ears, some loud," +
            " some soft. But utterly indiscernable", 0.1f, true);
    }
}

