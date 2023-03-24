using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class turretRegular : MonoBehaviour
{
	private Transform target;
	public bool canShoot;
	public float speed = 20f;
	public float reloadSpeed = 0.01f;
	public float radius = 100f;
	public GameObject bullet;
	public Transform shootSpot1;
	GameObject nearestEnemy = null;
	public GameObject enemy = null;
	public bool seeHidden = false;
	void FixedUpdate()
	{
		look4target();

		if (target != null)
		{
			if (Vector3.Distance(target.position, transform.position) > radius)
			{
				target = null;
			}

			if (Vector3.Distance(target.position, transform.position) <= radius && canShoot)
			{
					Vector3 vectorToTarget = target.position - transform.position;
					float angle = (Mathf.Atan2(vectorToTarget.z, vectorToTarget.x) * Mathf.Rad2Deg - 90f);
					Quaternion q = Quaternion.AngleAxis(angle, Vector3.down);
					transform.rotation = Quaternion.Slerp(transform.rotation, q, 1f);
					if (canShoot == true)

				//Vector3 dir = target.position - transform.position;
				//Quaternion lookRotation = Quaternion.LookRotation(dir);
				//Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speed).eulerAngles;
				//transform.rotation = Quaternion.Euler(0f, lookRotation.y, 0f);


				{
					shoot();
					canShoot = false;
				}
			}

		}
	}

	IEnumerator Reload()
	{
		yield return new WaitForSeconds(reloadSpeed);
		canShoot = true;
	}

	void shoot()
	{
		canShoot = false;
		Instantiate(bullet, shootSpot1.position, shootSpot1.rotation);
		StartCoroutine(Reload());

	}

	void look4target()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
			GameObject[] hiddenEnemies = GameObject.FindGameObjectsWithTag("hidden");

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
		if (seeHidden)
        {
			foreach (GameObject enemy in hiddenEnemies)
			{
				float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
				if (distanceToEnemy < shortestDistance)
				{
					shortestDistance = distanceToEnemy;
					nearestEnemy = enemy;
				}
			}
		}

			if (nearestEnemy != null && shortestDistance <= radius)
		{
			target = nearestEnemy.transform;
		}
		else
		{
			target = null;
		}
	}


	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
