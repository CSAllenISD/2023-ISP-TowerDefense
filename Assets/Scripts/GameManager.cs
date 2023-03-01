using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static bool gameEnded;
    public AudioSource audio;
    public GameObject gameOverUI;
    public GameManager gameManager;
    public string nextLevel = "Level02";
    public int LevelToUnlock = 2;
    public GameObject chicken;
    public AudioSource win;

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
        if (PlayerPrefs.GetInt("levelReached") < LevelToUnlock && gameEnded == false)
        {
            Time.timeScale = 1;
            PlayerPrefs.SetInt("levelReached", LevelToUnlock);
        }
        StartCoroutine(testthing());
    }

    IEnumerator testthing()
    {
        chicken.SetActive(true);
        win.Play();
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("LevelSelector");

    }
}
