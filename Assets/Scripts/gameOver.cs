using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class gameOver : MonoBehaviour
{
    public int countDown = 5;
    public float count;
    public TMP_Text text;
    void Update()
    {
        if (countDown > 0)
        {
            count += Time.deltaTime;
            if (count >= 1f)
            {
                count = 0f;
                countDown -= 1;
                text.text = "Restarting In: " + countDown;
            }
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
