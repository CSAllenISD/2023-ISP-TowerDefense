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
    public static int cash;
    public int startMoney = 300;

    public static int lives;
    public int startLives = 20;

    public static int Rounds;
    public int t1Cost;
    public int t3Cost;
    public int t4Cost;
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
        }
        if (cash >= t1Cost)
        {
            DartMonkey.interactable = true;
        }
        if (cash < t3Cost)
        {
            cannon.interactable = false;
        }
        if (cash >= t3Cost)
        {
            cannon.interactable = true;
        }
        if (cash < t4Cost)
        {
            snow.interactable = false;
        }
        if (cash >= t4Cost)
        {
            snow.interactable = true;
        }
        if (cash < 250)
        {
       //     TackShooter.interactable = false;
        }
        if (cash >= 250)
        {
        //    TackShooter.interactable = true;
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
