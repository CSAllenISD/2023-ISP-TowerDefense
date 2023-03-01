using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class selfTyping : MonoBehaviour
{

    public float delay = 0.1f;
    [Header("Make All of These Arrays the Same Length")]
    public string[] fullText;
    public int[] speaker;
    public int[] textAnimations;

    [Header("Misc")]
    private string currentText = "";
    public TMP_Text textBox;
    public TMP_Text nameBox;
    public AudioSource[] click;
    public bool canProceed = false;
    public int textPosition;
    public bool breaker = false;
    [Header("Character Attributes")]
    public string[] charNames;
    public Animator[] charAnimators;

    [Header("Robot's Face")]
    public GameObject[] happy;
    public GameObject[] confused;
    public GameObject[] angry;
    
    void Start()
    {
        textPosition = 0;
        StartCoroutine(ShowText(textPosition));
    }
    IEnumerator ShowText(int a)
    {
        if (speaker[a] == 1 && textAnimations[a] != 0)
        {
            for (int i = 0; i < (happy.Length); i++)
            {
                happy[i].SetActive(false);
            }
            for (int i = 0; i < (confused.Length); i++)
            {
                confused[i].SetActive(false);
            }
            for (int i = 0; i < (angry.Length); i++)
            {
                angry[i].SetActive(false);
            }
            switch (textAnimations[a])
            {
                case 1:

                    break;
                case 2:
                    for (int i = 0; i < (happy.Length); i++)
                    {
                        happy[i].SetActive(true);
                    }
                    break;
                case 3:

                    break;
                case 4:
                    //make sure to set the things to inactive first to prevent overlap
                    
                    for (int i = 0; i < (confused.Length); i++)
                    {
                        confused[i].SetActive(true);
                    }
                    break;
                case 5:
                    
                    for (int i = 0; i < (angry.Length); i++)
                    {
                        angry[i].SetActive(true);
                    }
                    break;
                case 6:

                    break;
                case 7:

                    break;


            }
        }
        nameBox.text = charNames[speaker[a]];
        if (charAnimators[speaker[a]] != null && textAnimations[a] != 0)
        {
            charAnimators[speaker[a]].SetTrigger(textAnimations[a].ToString());
        }
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
                if (fullText[textPosition].Length != currentText.Length)
                {
                    breaker = true;
                    StopCoroutine(ShowText(textPosition));
                    textBox.text = fullText[textPosition];
                    canProceed = true;
                }
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
