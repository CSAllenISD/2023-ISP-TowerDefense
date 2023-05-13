using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static bool gameEnded;
    public AudioSource audio;
    public GameObject gameOverUI;
    public GameManager gameManager;
    public string LevelToUnlock;
    public GameObject chicken;
    public AudioSource win;
    public PauseMenu pMenu;
    public bool freePlay = false;
    void Start()
    {
        gameEnded = false;
        WaveSpawner.EnemiesAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;
        if (playerStats.lives <= 0)
        {
            EndGame();
        }
    }


    void EndGame()
    {
        pMenu.canPause = false;
        gameEnded = true;
        audio.Play();
        Time.timeScale = 1;
        retryScreen();

    }
    public void retryScreen()
    {
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
            Time.timeScale = 1;
            PlayerPrefs.SetInt(LevelToUnlock, 1);
        PlayerPrefs.Save();
        StartCoroutine(testthing());
    }

    IEnumerator testthing()
    {
        pMenu.canPause = false;
        chicken.SetActive(true);
        win.Play();
        yield return new WaitForSeconds(5);
        Time.timeScale = 1;
        if (!freePlay)
        {
            SceneManager.LoadScene("LevelSelector");
        } else
        {
            SceneManager.LoadScene("TitleScene");
        }


    }

    }

