using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class UIAssistant : MonoBehaviour
{
    [SerializeField] public Button_UI buttonui;
    public Text messageText;
    private Text nameText;
    public int messageNum = 0;
    private TextWriting.TextWriterSingle textWriterSingle;

    // Start is called before the first frame update
    void Awake()
    {
        buttonui.ClickFunc = () =>
            {
                if (textWriterSingle != null && textWriterSingle.isActive())
                {
                    textWriterSingle.writeAllAndDestroy();
                }
                else
                {
                    string[] messageArray = new string[]
                    {
                    "The vague mumbling of voices reach their ears, some loud," +
            " some soft. But utterly indiscernable",
                    "Screaming flashes of red. Followed by seemingly unending darkness",
                    "Dull thuds rocked their body, jolting them about",
                    "Sights. Souunds. Feelings. All melded into a mindless swirl. Unidentifiable among" +
                    " the mist of senses",

                    };
                    string message = messageArray[messageNum];
                    textWriterSingle = TextWriting.TextWriter_Static(messageText, message, 0.05f, true, true, NextLine);
                }
            };
    }

    private void NextLine()
    {
        messageNum += 1;
    }
    // Update is called once per frame
    void Start()
    {

        //TextWriting.TextWriter_Static(messageText, "The vague mumbling of voices reach their ears, some loud," +
        //    " some soft. But utterly indiscernable", 0.1f, true);
    }
}

