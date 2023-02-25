using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    public float timeSpeed;




    void Start()
    {
        timeSpeed = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);
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
    public void unPause()
    {

        menu.SetActive(false);
        Time.timeScale = timeSpeed;



    }
}
