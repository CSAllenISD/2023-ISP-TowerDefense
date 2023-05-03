using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class playerStats : MonoBehaviour
{
    public TMP_Text cashText;
    public TMP_Text livesText;
    public Button DartMonkey;
    public Button music;
    public Button cannon;
    public Button snow;
    public Button spider;
    public Button star;
    public Button sniper;
    public static int cash;
    public int startMoney = 300;

    public static int lives;
    public int startLives = 20;

    public static int Rounds;
    public int t1Cost;
    public int t2Cost;
    public int t3Cost;
    public int t4Cost;
    public int t5Cost;
    public int t6Cost;
    public int t7Cost;
    public Color whiteColor;
    public Color notWhite;
    void Start()
    {
        Rounds = 0;
        cash = startMoney;
        lives = startLives;
           livesText.text = "Lives: " + lives;
              cashText.text = "$" + cash;
    }


    void Update()
    {
        if (cash < t1Cost)
        {
            DartMonkey.interactable = false;
            DartMonkey.gameObject.transform.GetChild(0).GetComponent<Image>().color = notWhite;
        }
        if (cash >= t2Cost)
        {
            DartMonkey.interactable = true;
            DartMonkey.gameObject.transform.GetChild(0).GetComponent<Image>().color = whiteColor;
        }
        if (cash < t1Cost)
        {
            music.interactable = false;
            music.gameObject.transform.GetChild(0).GetComponent<Image>().color = notWhite;
        }
        if (cash >= t2Cost)
        {
            music.interactable = true;
            music.gameObject.transform.GetChild(0).GetComponent<Image>().color = whiteColor;
        }
        if (cash < t3Cost)
        {
            cannon.interactable = false;
            cannon.gameObject.transform.GetChild(0).GetComponent<Image>().color = notWhite;
        }
        if (cash >= t3Cost)
        {
            cannon.interactable = true;
            cannon.gameObject.transform.GetChild(0).GetComponent<Image>().color = whiteColor;
        }
        if (cash < t4Cost)
        {
            snow.interactable = false;
            snow.gameObject.transform.GetChild(0).GetComponent<Image>().color = notWhite;
        }
        if (cash >= t4Cost)
        {
            snow.interactable = true;
            snow.gameObject.transform.GetChild(0).GetComponent<Image>().color = whiteColor;
        }
        if (cash < t5Cost)
        {
            spider.interactable = false;
            spider.gameObject.transform.GetChild(0).GetComponent<Image>().color = notWhite;
        }
        if (cash >= t5Cost)
        {
            spider.interactable = true;
            spider.gameObject.transform.GetChild(0).GetComponent<Image>().color = whiteColor;
        }
        if (cash < t6Cost)
        {
            star.interactable = false;
            star.gameObject.transform.GetChild(0).GetComponent<Image>().color = notWhite;
        }
        if (cash >= t6Cost)
        {
            star.interactable = true;
            star.gameObject.transform.GetChild(0).GetComponent<Image>().color = whiteColor;
        }
        if (cash < t7Cost)
        {
            sniper.interactable = false;
            sniper.gameObject.transform.GetChild(0).GetComponent<Image>().color = notWhite;
        }
        if (cash >= t7Cost)
        {
            sniper.interactable = true;
            sniper.gameObject.transform.GetChild(0).GetComponent<Image>().color = whiteColor;
        }
    }
    public void addCash(int money)
    {
        cash += money;
        cashText.text = "Cash: $" + cash;
    }
    public void loseLife(int hp)
    {
        lives -= hp;
        if (hp < 0)
        {
            hp = 0;
        }
        livesText.text = "Lives: " + lives;
    }

}
