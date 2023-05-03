using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class levelSelector : MonoBehaviour
{

    public Button[] levelButtons;
    public GameObject[] lockImage;
    public GameObject[] levelIcon;

    void Start()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (!PlayerPrefs.HasKey("level" + i))
            {
                PlayerPrefs.SetInt("level" + i, 0);
            }
        }
        PlayerPrefs.Save();
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (PlayerPrefs.GetInt("level" + i) == 1)
            {
                levelButtons[i].interactable = true;
                lockImage[i].SetActive(false);
                levelIcon[i].SetActive(true);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void testSave(string sus)
    {
        if (sus != "reset")
        {
            PlayerPrefs.SetInt(sus, 1);

        }
        else
        {
            PlayerPrefs.DeleteAll();
        }
        PlayerPrefs.Save();
    }
    public void chooseScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
