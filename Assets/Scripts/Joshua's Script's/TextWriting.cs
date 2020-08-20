using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TextWriting : MonoBehaviour
{
    private static TextWriting instance;
    private List<TextWriterSingle> textWriterSingleList;

    public void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public static void TextWriter_Static(Text uiText, string toBeWritten, float characterSpeed, bool invisibleCharacters)
    {
        instance.TextWriter(uiText,toBeWritten,characterSpeed,invisibleCharacters);
    }

    public void TextWriter(Text uiText, string toBeWritten, float characterSpeed, bool invisibleCharacters)
    {
        textWriterSingleList.Add(new TextWriterSingle(uiText, toBeWritten, characterSpeed, invisibleCharacters));
    }

    private void Update()
    {
        Debug.Log(textWriterSingleList.Count);
            for (int i = 0; i < textWriterSingleList.Count; i++)
            {
                bool destroyInstance = textWriterSingleList[i].Update();

                if(destroyInstance)
                {
                    textWriterSingleList.RemoveAt(i);
                }
            }

    }

    //Represents a single instance
    public class TextWriterSingle
    {
        private Text uiText;
        private string toBeWritten;
        private int characterIndex;
        private float characterSpeed;
        private float timer;
        private bool invisibleCharacters;

        public TextWriterSingle(Text uiText, string toBeWritten, float characterSpeed, bool invisibleCharacters)
        {
            this.uiText = uiText;
            this.toBeWritten = toBeWritten;
            this.characterSpeed = characterSpeed;
            this.invisibleCharacters = invisibleCharacters;
            characterIndex = 0;
        }

        //Returns true on completion
        public bool Update()
        {
            timer -= Time.deltaTime;
            while (timer <= 0)
            {
                timer += characterSpeed;
                characterIndex++;
                string text = toBeWritten.Substring(0, characterIndex);

                if (invisibleCharacters)
                {
                    //For some stupid reason, there can be no spaces in the color. Otherwise it won't work
                    text += "<color=#00000000>" + toBeWritten.Substring(characterIndex) + "</color>";

                }

                uiText.text = text;
                if (characterIndex >= toBeWritten.Length)
                {
                    return true;
                }
            }
            return false;
        }
    }

}