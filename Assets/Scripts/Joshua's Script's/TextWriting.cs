using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriting : MonoBehaviour
{
    private Text uiText;
    private string toBeWritten;
    private int characterIndex;
    private float characterSpeed;
    private float timer;

    public void TextWriter(Text uiText, string toBeWritten, float characterSpeed)
    {
        this.uiText = uiText;
        this.toBeWritten = toBeWritten;
        this.characterSpeed = characterSpeed;
        characterIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer += characterSpeed;
                characterIndex++;
                uiText.text = toBeWritten.Substring(0, characterIndex);

            }
        }
    }
}
