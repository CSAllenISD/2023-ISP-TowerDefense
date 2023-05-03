using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncloud : MonoBehaviour
{
    public float timerMax;
    public float timer;
    public GameObject cloud;
    void Start()
    {
        timer = timerMax;
    }
    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        } else
        {
            timer = timerMax;
            Instantiate(cloud, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
