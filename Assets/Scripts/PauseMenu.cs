using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    public float timeSpeed;
    public GameObject autoStartImage;
    public GameObject pause;
    public GameObject settings;
    public AudioMixer audioMixer;
    public Slider slider;
    public bool canPause;
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            audioMixer.SetFloat("volume", 20);
            PlayerPrefs.SetFloat("volume", 20);
            PlayerPrefs.Save();
        }
        slider.value = PlayerPrefs.GetFloat("volume");
        if (!PlayerPrefs.HasKey("autoStart"))
        {
            PlayerPrefs.SetInt("autoStart", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt("autoStart") == 1)
        {
            autoStartImage.SetActive(true);
        }
            timeSpeed = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);
                pause.SetActive(true);
                settings.SetActive(false);
                Time.timeScale = timeSpeed;

            }
            else
            {
                menu.SetActive(true);
                timeSpeed = Time.timeScale;
                Time.timeScale = 0f;

            }

        }
    }

    public void openSettings()
    {
        pause.SetActive(false);
        settings.SetActive(true);
    }


    public void closeSettings()
    {
        pause.SetActive(true);
        settings.SetActive(false);
    }
    public void unPause()
    {

        menu.SetActive(false);
        pause.SetActive(true);
        settings.SetActive(false);
        Time.timeScale = timeSpeed;



    }

    public void toggleAutoStart()
    {
        if (PlayerPrefs.HasKey("autoStart"))
        {
            if (PlayerPrefs.GetInt("autoStart") == 1)
            {
                autoStartImage.SetActive(false);
                PlayerPrefs.SetInt("autoStart", 0);
            } else
            {
                PlayerPrefs.SetInt("autoStart", 1);
                autoStartImage.SetActive(true);
            }
        } else
        {
            PlayerPrefs.SetInt("autoStart", 1);
            autoStartImage.SetActive(true);
        }
        PlayerPrefs.Save();
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }
}
