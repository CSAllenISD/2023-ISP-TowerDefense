using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 0.2f;
    public Rigidbody rb;
    public int pierce;
    public int damage = 1;
    public bool minigun = false;
    public float explosionRadius;
    public int explosionDamage;
    public GameObject explosion;
    public bool stunShot;
    public float freezetime;
    public bool spawner = false;
    public Transform Pos1;
    public Transform Pos2;
    public Transform Pos3;
    public Transform Pos4;
    public GameObject secondShot;
    public bool hitHidden = false;
    public bool slow = false;
    public bool kb = false;
    public float poisonValue = 0;
    void Start()
    {
        if (minigun == false)
        {
            rb.velocity = transform.forward * speed;
            StartCoroutine(die());
        }
        if (minigun == true)
        {
            rb.velocity = transform.right * speed;
            StartCoroutine(die());
        }
    }
    void Update()
    {
        if (pierce <= 0)
        {
            if (explosionRadius > 0)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
                GameObject explosionEffect = Instantiate(explosion, transform.position, transform.rotation);
                Destroy(explosionEffect, 1f);

                foreach (Collider collider in colliders)
                {
                    if (collider.tag == "enemy")
                    {
                        var enemy = collider.gameObject.GetComponent<enemy>();
                        enemy.TakeDamage(explosionDamage);
                        if (slow)
                        {
                            enemy.slow(freezetime);
                        }
                        if (stunShot == true)
                        {
                            enemy.freeze(freezetime);
                        }
                        if (kb)
                        {
                            enemy.backwards(freezetime);
                        }
                    }
                }
            }
            if (spawner == true)
            {
                Instantiate(secondShot, Pos1.position, Pos1.rotation);
                Instantiate(secondShot, Pos2.position, Pos2.rotation);
                Instantiate(secondShot, Pos3.position, Pos3.rotation);
                Instantiate(secondShot, Pos4.position, Pos4.rotation);

            }
            Destroy(gameObject);
        }
    }
    IEnumerator die()
    {

        yield return new WaitForSeconds(lifetime);
        if (explosionRadius > 0)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            Instantiate(explosion, transform.position, transform.rotation);

            foreach (Collider collider in colliders)
            {
                if (collider.tag == "enemy")
                {
                    var enemy = collider.gameObject.GetComponent<enemy>();
                    enemy.TakeDamage(explosionDamage);

                }
            }
        }
        if (spawner == true)
        {
            Instantiate(secondShot, Pos1.position, Pos1.rotation);
            Instantiate(secondShot, Pos2.position, Pos2.rotation);
            Instantiate(secondShot, Pos3.position, Pos3.rotation);
            Instantiate(secondShot, Pos4.position, Pos4.rotation);

        }
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider thing)
    {
        if (thing.tag == "enemy" || (thing.tag == "hidden" && hitHidden == true))
        {
            pierce -= 1;
            Debug.Log("hit");

            var enemy = thing.gameObject.GetComponent<enemy>();
            if (enemy.isRainbow)
            {
                Destroy(gameObject);
            }
            if (pierce >= 0)
            {
                enemy.TakeDamage(damage);
                if (stunShot == true)
                {
                    enemy.freeze(freezetime);
                }
                if (slow)
                {
                    enemy.slow(freezetime);
                }
                if (kb)
                {
                    enemy.backwards(freezetime);
                }
                    enemy.poisonValue = poisonValue;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }


    public void HitBall()
    {
        rb.velocity = transform.up * speed * 5;
    }
}
