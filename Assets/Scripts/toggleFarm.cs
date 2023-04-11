using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleFarm : MonoBehaviour
{
    public GameObject farm;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            farm.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            farm.SetActive(false);
        }
    }
}
