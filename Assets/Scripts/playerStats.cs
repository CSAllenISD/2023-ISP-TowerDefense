using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerStats : MonoBehaviour
{
    public int lives;
    public int cash;
    public Text cashText;
    public Text livesText;
    public Button DartMonkey;
    public Button TackShooter;
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
    void Start()
    {
        lives = 100;
        cash = 650;
     //   livesText.text = "Lives: " + lives;
  //      cashText.text = "Cash: $" + cash;
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
