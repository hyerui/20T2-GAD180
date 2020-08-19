using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriting : MonoBehaviour
{
    private TextWriterSingle textWriterSingle;
    public void TextWriter(Text uiText, string toBeWritten, float characterSpeed, bool invisibleCharacters)
    {
        textWriterSingle = new TextWriterSingle(uiText, toBeWritten, characterSpeed, invisibleCharacters);
    
    }

    private void Update()
    {
        if (textWriterSingle != null)
        {
            textWriterSingle.Update();
        }
    }

}

public class TextWriterSingle
{
    private Text uiText;
    private string toBeWritten;
    private int characterIndex;
    private float characterSpeed;
    private float timer;

    //Essentially writes out the text before displaying it so that each letter is rendered in it's spot
    private bool invisibleCharacters;

    public TextWriterSingle(Text uiText, string toBeWritten, float characterSpeed, bool invisibleCharacters)
    {
        this.uiText = uiText;
        this.toBeWritten = toBeWritten;
        this.characterSpeed = characterSpeed;
        this.invisibleCharacters = invisibleCharacters;
        characterIndex = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                timer += characterSpeed;
                characterIndex++;
                string text = toBeWritten.Substring(0, characterIndex);

                if (invisibleCharacters)
                {
                    text += "<color = #00000000>" + toBeWritten.Substring(characterIndex) + "</color>";
                }

                uiText.text = text;

                if (characterIndex >= toBeWritten.Length)
                {
                    uiText = null;
                    return;
                }
            }
        }
    }
};
