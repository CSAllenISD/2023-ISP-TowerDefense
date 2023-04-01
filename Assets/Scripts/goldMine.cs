using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldMine : MonoBehaviour
{
    public WaveSpawner wSpawner;
    public int cashValue;
    public float timeIntervals;
    public float currentTime;
    public playerStats pStats;
    public GameObject moneyEffect;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeIntervals;
        GameObject[] stats = GameObject.FindGameObjectsWithTag("statistics");
        pStats = stats[0].GetComponent<playerStats>();
        GameObject[] waveManager = GameObject.FindGameObjectsWithTag("waveSpawner");
        wSpawner = waveManager[0].GetComponent<WaveSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wSpawner.inRound)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = timeIntervals;
                pStats.addCash(cashValue);
                Instantiate(moneyEffect, transform.position, transform.rotation);
            }
        }
        
    }
}
