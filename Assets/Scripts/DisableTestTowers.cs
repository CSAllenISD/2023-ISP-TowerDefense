using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTestTowers : MonoBehaviour
{
    public GameObject cactus1;
    public GameObject cactus2;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (cactus1.active)
            {
                cactus1.SetActive(false);
            } else
            {
                cactus1.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (cactus2.active)
            {
                cactus2.SetActive(false);
            }
            else
            {
                cactus2.SetActive(true);
            }
        }
    }
}
