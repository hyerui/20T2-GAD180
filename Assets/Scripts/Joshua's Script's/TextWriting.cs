using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System;
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

    public static TextWriterSingle TextWriter_Static(Text uiText, string toBeWritten, float characterSpeed, bool invisibleCharacters, bool removeWriterBeforeAdd, Action onComplete)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.TextWriter(uiText,toBeWritten,characterSpeed,invisibleCharacters, onComplete);
    }

    public TextWriterSingle TextWriter(Text uiText, string toBeWritten, float characterSpeed, bool invisibleCharacters, Action onComplete)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, toBeWritten, characterSpeed, invisibleCharacters, onComplete);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    public static void RemoveWriter_Static(Text uiText)
    {
        instance.RemoveWriter(uiText);
    }

    private void RemoveWriter(Text uiText)
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            if (textWriterSingleList[i].getUIText() == uiText)
            {
                textWriterSingleList.RemoveAt(i);
            }
        }
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
        private Action onComplete;

        public TextWriterSingle(Text uiText, string toBeWritten, float characterSpeed, bool invisibleCharacters, Action onComplete)
        {
            this.uiText = uiText;
            this.toBeWritten = toBeWritten;
            this.characterSpeed = characterSpeed;
            this.invisibleCharacters = invisibleCharacters;
            this.onComplete = onComplete;
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
                    if (onComplete != null) onComplete();
                    return true;
                }
            }
            return false;
        }
        public Text getUIText()
        {
            return uiText;
        }

        public bool isActive()
        {
            return characterIndex < toBeWritten.Length;

        }

        public void writeAllAndDestroy()
        {
            uiText.text = toBeWritten;
            characterIndex = toBeWritten.Length;
            if (onComplete != null) onComplete();
            TextWriting.RemoveWriter_Static(uiText);
        }
    }


}