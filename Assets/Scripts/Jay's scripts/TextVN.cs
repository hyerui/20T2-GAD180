using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextVN : MonoBehaviour
{
    public TextAsset testTextAsset;
    private string testString;
    private List<string> eachLine;
    private int textCounter;


    public Text dialogueText;
    public Text nameText;
    public int[] nameSwitches;
    public string[] names;

    private bool isTyping;

    void Start()
    {
        testString = testTextAsset.text;

        textCounter = -1;

        eachLine = new List<string>();
        eachLine.AddRange(testString.Split("\n"[0]));
    }

    void Update()
    {
        int total = eachLine.Count;

        if (Input.GetKeyDown(KeyCode.Space) &&
            textCounter < (total - 1) &&
            isTyping == false)
        {
            StopAllCoroutines();
            ++textCounter;
            StartCoroutine(TypeSentence(eachLine[textCounter]));
        }

        if (textCounter < 0)
        {
            dialogueText.text = ("");
            nameText.text = ("");
        }

        // PURELY FOR TESTING
        if (Input.GetKeyDown(KeyCode.Q))
        {
            textCounter = -1;
        }

        // changes name based on which line
        for (int i = 0; i < (total - 1); ++i)
        {
            if (nameSwitches[i] == textCounter)
            {
                nameText.text = names[i].ToString();
            }
        }

        IEnumerator TypeSentence (string sentence)
        {
            dialogueText.text = "";
            foreach (char letter in eachLine[textCounter].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.05f);
                isTyping = true;
            }
            isTyping = false;
        }

        if (isTyping == true &&
            Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            isTyping = false;
            dialogueText.text = eachLine[textCounter].ToString();
        }
    }
}
