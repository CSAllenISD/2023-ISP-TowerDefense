using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intervalStun : MonoBehaviour
{
    public float timer = 10f;
    public float maxTime = 10f;
    public float explosionRadius;
    public float freezetime;
    public Animator GUIAnim;
    void Start()
    {
        GameObject[] muse = GameObject.FindGameObjectsWithTag("MusicAnimation");
        GUIAnim = muse[0].GetComponent<Animator>();
    }
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        } else
        {
            GUIAnim.SetTrigger("play");
            stun();
            timer = maxTime;
        }
    }
    public void stun()
    {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "enemy")
                {
                    var enemy = collider.gameObject.GetComponent<enemy>();
                        enemy.freeze(freezetime);
                }
            }
        }
}
