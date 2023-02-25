using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class selfTyping : MonoBehaviour
{
    public float delay = 0.1f;
    public string[] fullText;
    private string currentText = "";
    public TMP_Text textBox;
    public AudioSource[] click;
    public bool canProceed = false;
    public int textPosition;
    public bool breaker = false;
    void Start()
    {
        textPosition = 0;
        StartCoroutine(ShowText(textPosition));
    }
    IEnumerator ShowText(int a)
    {
        for (int i = 0; i < (fullText[a].Length + 1); i++)
        {
            if (breaker)
            {
                breaker = false;
                yield break;
            }
            currentText = fullText[a].Substring(0, i);
            textBox.text = currentText;
            if (!(currentText.EndsWith(" ")))
            {
                click[Random.Range(0, 5)].Play();
            }
            
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(0.1f);
        canProceed = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canProceed)
            {
                nextText();
            } else
            {
                breaker = true;
                StopCoroutine(ShowText(textPosition));
                textBox.text = fullText[textPosition];
                canProceed = true;
            }
        }
    }

    public void nextText()
        {
        canProceed = false;
        textPosition += 1;
        if (textPosition < fullText.Length)
        {
            StartCoroutine(ShowText(textPosition));
        } else
        {
            Debug.Log("text has ended!");
        }
    }
}
