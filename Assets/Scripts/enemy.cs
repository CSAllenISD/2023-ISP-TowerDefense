using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class enemy : MonoBehaviour
{
    public GameObject parentObject;
    public SpriteRenderer m_SpriteRenderer;
    public float speed = 10f;
    public Transform ParentTransform;
    public bool isMoab;
    public GameObject kid;
    enemy script;
    float tempSpeed;
    public bool isCeramic;
    public int wavething = 0;
    public int health = 4;


    public int value = 10;

    public GameObject deathEffect;

    private Transform target;
    private int wavepointIndex = 0;
    public Transform child1;
    public Transform child2;
    public Transform child3;
    public Transform child4;
    public AudioSource CeramicHit;
    public AudioSource MoabDie;
    public GameObject Popsound;
    public playerStats playerStats;
    public bool isRainbow;
    public bool isStefano = true;
    public bool isDead = false;
    public int RBE = 1;
    void Start()
    {

        GameObject scriptthing = GameObject.FindWithTag("statistics");
        playerStats = scriptthing.GetComponent<playerStats>();
        target = waypoint.points[wavepointIndex];

    }

    public void TakeDamage(int amount)
    {

        if (isMoab != true)
        {
            if (amount > health && health > 0)
            {
                playerStats.addCash(health);
            }
            else if (amount < health)
            {
                playerStats.addCash(amount);
            }
            else if (amount > health && health < 0)
            {
                playerStats.addCash(1);
            }

            health -= amount;
        //    Instantiate(Popsound, ParentTransform.position, Quaternion.identity);


            if (health <= 0 && isDead == false)
            {
                isDead = true;
           //     Instantiate(Popsound, ParentTransform.position, Quaternion.identity);

                Die();
            }
        }
        if (isMoab == true)
        {
            if (isCeramic)
            {
         //       Instantiate(Popsound, ParentTransform.position, Quaternion.identity);

            }
            health -= amount;

        }
    }

    void Die()
    {
        if (health <= 0)
        {
         //   Instantiate(Popsound, ParentTransform.position, Quaternion.identity);

            wavething = wavepointIndex;
            if (isMoab == true)
            {
                GameObject child = Instantiate(kid, child1.position, parentObject.transform.rotation);
                GameObject theson = child.transform.GetChild(0).gameObject;
                script = theson.GetComponent<enemy>();
                if (script != null)
                {
                    script.ChangeWayPoint(wavething);
                }
                if (child2 != null)
                {
                    wavething = wavepointIndex;
                    child = Instantiate(kid, child2.position, parentObject.transform.rotation);
                    theson = child.transform.GetChild(0).gameObject;
                    script = theson.GetComponent<enemy>();
                    if (script != null)
                    {
                        script.ChangeWayPoint(wavething);
                    }
                }
                if (child3 != null)
                {
                    wavething = wavepointIndex;
                    child = Instantiate(kid, child3.position, parentObject.transform.rotation);
                    theson = child.transform.GetChild(0).gameObject;
                    script = theson.GetComponent<enemy>();
                    if (script != null)
                    {
                        script.ChangeWayPoint(wavething);
                    }
                }
                if (child4 != null)
                {
                    wavething = wavepointIndex;
                    child = Instantiate(kid, child4.position, parentObject.transform.rotation);
                    theson = child.transform.GetChild(0).gameObject;
                    script = theson.GetComponent<enemy>();
                    if (script != null)
                    {
                        script.ChangeWayPoint(wavething);
                    }
                }
            }
        }
            playerStats.addCash(value);
        GameObject effect = (GameObject)Instantiate(deathEffect, ParentTransform.position, Quaternion.identity);
        Destroy(effect, 0.1f);
        WaveSpawner.EnemiesAlive--;
        Destroy(parentObject);
    }


    void Update()
    {
        if (health <= 0)
        {
            isDead = true;
            Die();
        }
        if (isMoab == true && isCeramic == false && isRainbow == false && Vector3.Distance(ParentTransform.position, target.position) >= 200f && isStefano == false)
        {
            Vector3 vectorToTarget = waypoint.points[wavepointIndex].transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            ParentTransform.rotation = Quaternion.Slerp(transform.rotation, q, 50f);
        }
        Vector3 dir = target.position - ParentTransform.position;
        ParentTransform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(ParentTransform.position, target.position) <= 5f)
        {
            GetNextWaypoint();

        }

    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= waypoint.points.Length - 1)
        {
            EndPath();
            //wavepointIndex = -1; TO MAKE THE ENEMY CONTINUE TO LOOP UN-COMMENT THIS AND COMMENT THE LINE ABOVE AND BELOW THIS XOXO
            return;
        }
        wavepointIndex += 1;

        target = waypoint.points[wavepointIndex];
    }

    void EndPath()
    {
        if (isRainbow == true)
        {
            playerStats.loseLife(0);
        }
        if (isMoab == true && isCeramic == false)
        {
            playerStats.loseLife(616);
        }
        if (isCeramic == true)
        {
            playerStats.loseLife(104);
        }
        if (isRainbow == false && isMoab == false)
        {
            playerStats.loseLife(health);
        }
        WaveSpawner.EnemiesAlive--;
        Destroy(parentObject);

    }

    public void ChangeWayPoint(int point)
    {
        wavepointIndex = point;
    }

    public void freeze(float time)
    {
        if (isMoab == false)
        {
            if (speed != 0)
            {
                tempSpeed = speed;
                speed = 0f;
                StartCoroutine(regularspeed(time));
            }
        }
    }

    IEnumerator regularspeed(float time)
    {
        yield return new WaitForSeconds(time);
        speed = tempSpeed;
    }
    public void backwards(float time)
    {
        if (isMoab == false)
        {
            if (speed >= 0)
            {
                tempSpeed = speed;
                speed = -1 * tempSpeed;
                StartCoroutine(regularspeed(time));
            }
        }
    }
}

