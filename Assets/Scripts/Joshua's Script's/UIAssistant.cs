using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private TextWriting textWriting;
    private Text messageText;

    // Start is called before the first frame update
    void Awake()
    {
        //Creates a reference for a textfield
        //First string finds the location of the object with the same name, second one finds a reference to the object inside with the inserted name
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Start()
    {
        textWriting.TextWriter(messageText, "Hello World", 0.1f);
    }
}
