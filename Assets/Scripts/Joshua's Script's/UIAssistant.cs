using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class UIAssistant : MonoBehaviour
{
    [SerializeField] private TextWriting textWriting;
    private Text messageText;
    private Text nameText;

    // Start is called before the first frame update
    void Awake()
    {
        //Creates a reference for a textfield
        //First string finds the location of the object with the same name, second one finds a reference to the object inside with the inserted name
        messageText = transform.Find("Text Box").Find("Story").GetComponent<Text>();
        nameText = transform.Find("Text Box").Find("Name").GetComponent<Text>();
    }

    // Update is called once per frame
    void Start()
    {

        textWriting.TextWriter(messageText, "The mumbling of voices vaguely reaches their ears. Some loud" +
            ", some soft. Yet utterly indescernible", 0.1f, true);
        textWriting.TextWriter(nameText, "", 0f, true);

    }
}

