using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerStats : MonoBehaviour
{
    public Text cashText;
    public Text livesText;
    public Button DartMonkey;
    public Button TackShooter;


    public static int cash;
    public int startMoney = 300;

    public static int lives;
    public int startLives = 20;

    public static int Rounds;
    void Start()
    {
        Rounds = 0;
        cash = startMoney;
        lives = startLives;
        //   livesText.text = "Lives: " + lives;
        //      cashText.text = "Cash: $" + cash;
    }


    void Update()
    {
        if (cash < 215)
        {
         //   DartMonkey.interactable = false;
        }
        if (cash >= 215)
        {
       //     DartMonkey.interactable = true;
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
      //  cashText.text = "Cash: $" + cash;
    }
    public void loseLife(int hp)
    {
        lives -= hp;
     //   livesText.text = "Lives: " + lives;
    }

}
