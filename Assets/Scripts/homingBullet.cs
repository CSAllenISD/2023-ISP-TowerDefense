using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingBullet : MonoBehaviour
{
	private Transform target;
	public bool canShoot;
	public float homeSpeed = 20f;
	public Rigidbody rb;
	public float speed = 5f;
	public int pierce = 1;
	public int damage = 1;
	public float lifetime = 5f;
	public bool canHome = true;
	GameObject nearestEnemy = null;
	public GameObject enemy = null;
	public float homeTimer;
	public float maxTime;

	void Start()
	{
		StartCoroutine(die());
	}
	void Update()
	{
		rb.velocity = transform.forward * speed;

		if (pierce <= 0)
		{
			Destroy(gameObject);
		}
	}
	void FixedUpdate()
	{
		if (!canHome)
        {
			homeTimer -= Time.deltaTime;
			if (homeTimer <= 0)
            {
				homeTimer = maxTime;
				canHome = true;
            }
        }
		look4target();

		if (target != null && canHome)
		{



			Vector3 vectorToTarget = target.position - transform.position;
			float angle = (Mathf.Atan2(vectorToTarget.z, vectorToTarget.x) * Mathf.Rad2Deg - 90f);
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.down);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * homeSpeed);
		}
	}
	void look4target()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
		float shortestDistance = Mathf.Infinity;

		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}
		if (nearestEnemy != null)
		{
			target = nearestEnemy.transform;
		}
		else
		{
			target = null;
		}
	}
	void OnTriggerEnter(Collider thing)
	{
		if (thing.tag == "enemy")
		{
			pierce -= 1;
			Debug.Log("hit");
			var enemy = thing.gameObject.GetComponent<enemy>();
			enemy.TakeDamage(damage);
			canHome = false;
		}
	}

	IEnumerator die()
	{

		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);
	}
}
