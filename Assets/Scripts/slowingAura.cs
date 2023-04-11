using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowingAura : MonoBehaviour
{
    void OnTriggerStay(Collider thing)
    {
        if (thing.tag == "enemy" || (thing.tag == "hidden"))
        {
            var enemy = thing.gameObject.GetComponent<enemy>();
            if (enemy.isRainbow)
            {
                Destroy(gameObject);
            }
             enemy.slow(0.05f);
        }
    }
}
