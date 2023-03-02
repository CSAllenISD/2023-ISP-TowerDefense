using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Logic : MonoBehaviour
{
    [Header("Animators")]
    public Animator logicButton;
    public Animator backButton;
    public Animator logicBackDrop;
    public Animator connectButton;

    [Header("Logic Points")]
    public string[] logicDescription;
    public bool[] hasLogic;
    public GameObject[] logicImages;
    public GameObject textBox;
    public TMP_Text textBoxText;
    public bool menuOpen;
    public GameObject allPoints;
    public Button[] pointButtons;
    public Button cButton;
    public Outline[] pointOutline;
    public bool[] selectedLogic;
    public int[] connectsWith; //The point in the index of this array connects with the value in that index, so if connectsWith[0] = 2, then logic number 0 connects with logic number 2. >v<

    [Header("Misc")]
    public GameObject[] logicMenu;
    public GameObject[] connection;
    public GameObject noConnection;
    public GameObject tBox;
    public GameObject nBox;
    void Update()
    {
        if (menuOpen)
        {
            for (int i = 0; i < (hasLogic.Length); i++)
            {
                if (hasLogic[i])
                {
                    logicImages[i].SetActive(true);
                }
                else
                {
                    logicImages[i].SetActive(false);
                }
            }
        } 
    }
    public void openMenu()
    {
        for (int i = 0; i < (hasLogic.Length); i++)
        {
            pointButtons[i].interactable = true;

        }
        menuOpen = true;
        logicBackDrop.SetBool("onScreen", true);
        logicButton.SetBool("onScreen", false);
        backButton.SetBool("onScreen", true);
        StartCoroutine(showPoints());
    }
    public void closeMenu()
    {
        for (int i = 0; i < (hasLogic.Length); i++)
        {
            pointButtons[i].interactable = false;
            pointOutline[i].enabled = false;

        }
            logicButton.SetBool("onScreen", true);
        backButton.SetBool("onScreen", false);
        logicBackDrop.SetBool("onScreen", false);
        connectButton.SetBool("onScreen", false);
        cButton.interactable = false;
        menuOpen = false;
        StartCoroutine(hidePoints());
    }

    public void showDescription(int logicPoint)
    {
        textBox.SetActive(true);
        textBoxText.text = logicDescription[logicPoint];
    }
    public void hideDescription()
    {
        textBox.SetActive(false);
        textBoxText.text = " ";
    }
    IEnumerator showPoints()
    {
        yield return new WaitForSeconds(0.25f);
        if (menuOpen)
        {
            allPoints.SetActive(true);
        }
    }
    IEnumerator hidePoints()
    {
        yield return new WaitForSeconds(0.25f);
        if (!menuOpen)
        {
            hideDescription();
            allPoints.SetActive(false);
        }
    }

    public void selectPoint(int pointPosition)
    {
        int amountEnabled = 0;
        for (int i = 0; i < (hasLogic.Length); i++)
        {
            if (pointOutline[i].enabled == true)
            {
                amountEnabled++;
            }

        }
        if (!pointOutline[pointPosition].enabled && amountEnabled < 2)
        {
            pointOutline[pointPosition].enabled = true;

            
        } else
        {
            pointOutline[pointPosition].enabled = false;
            cButton.interactable = false;
            connectButton.SetBool("onScreen", false);
        }
        amountEnabled = 0;
        for (int i = 0; i < (hasLogic.Length); i++)
        {
            if (pointOutline[i].enabled == true)
            {
                amountEnabled++;
            }

        }
        if (amountEnabled == 2)
        {
            cButton.interactable = true;
            connectButton.SetBool("onScreen", true);
        }
    }

    public void connectPoints()
    {
        cButton.interactable = false;
        StartCoroutine(hidePoints());
        allPoints.SetActive(false);
        for (int i = 0; i < (hasLogic.Length); i++)
        {
            if (pointOutline[i].enabled == true)
            {
                selectedLogic[i] = true;
                pointOutline[i].enabled = false;
            } else
            {
                selectedLogic[i] = false;
            }

        }
        int connectedPoint1 = -1;
        int connectedPoint2 = -1;
        bool success = false;
        for (int i = 0; i < (hasLogic.Length); i++)
        {
            if (selectedLogic[i] && selectedLogic[connectsWith[i]])
            {
                success = true;
                Debug.Log("successfully connected point " + i + " and point " + connectsWith[i]);
                connectedPoint1 = i;
                connectedPoint2 = connectsWith[i];
                i = hasLogic.Length;
                for (int a = 0; a < (logicMenu.Length); a++)
                { 
                    logicMenu[a].SetActive(false);
                }
                connection[connectedPoint1].SetActive(true);
                tBox.SetActive(true);
                nBox.SetActive(true);
            }
        }
        if (!success)
        {
            Debug.Log("The two points do not connect.");
            for (int a = 0; a < (logicMenu.Length); a++)
            {
                logicMenu[a].SetActive(false);
            }
            noConnection.SetActive(true);
            tBox.SetActive(true);
            nBox.SetActive(true);
        }
    }
}
