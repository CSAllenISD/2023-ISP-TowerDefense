using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderSlow : MonoBehaviour
{
    public bool hitHidden = false;
    public float freezetime = 0.1f;
    public float lifeTime;
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "enemy" || (other.tag == "hidden" && hitHidden == true))
        {
         var enemy = other.gameObject.GetComponent<enemy>();

         enemy.slow(freezetime);

        }

    }
}

