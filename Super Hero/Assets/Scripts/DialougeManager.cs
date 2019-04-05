using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialougeManager : MonoBehaviour
{
    public TextMeshProUGUI dialougeText;

    public float typingSpeed;

    public string[] sentences;
    private int index;

    void Start()
    {
        StartCoroutine(Type());
        dialougeText.text = "";
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToString())
        {
            dialougeText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            dialougeText.text = "";
            StartCoroutine(Type());
        }

        else
        {
            dialougeText.text = "";
        }
    }

}
