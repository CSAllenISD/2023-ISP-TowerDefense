using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class turret_star : MonoBehaviour
{
	public WaveSpawner wSpawner;
	private Transform target;
	public bool canShoot;
	public float speed = 20f;
	public float reloadSpeed = 0.01f;
	public float radius = 100f;
	public GameObject bullet;
	public Transform shootSpot1;
	public Transform shootSpot2;
	public Transform shootSpot3;
	public Transform shootSpot4;
	public Transform shootSpot5;
	public Transform shootSpot6;
	public Transform shootSpot7;
	public Transform shootSpot8;
	GameObject nearestEnemy = null;
	public GameObject enemy = null;
	public bool seeHidden = false;
	public bool shootAnim = false;
	public bool tripleCannon = false;
	public Animator attackAnimator;
	void Start()
    {
		GameObject[] waveManager = GameObject.FindGameObjectsWithTag("waveSpawner");
		wSpawner = waveManager[0].GetComponent<WaveSpawner>();
	}
	void FixedUpdate()
	{
		if (wSpawner.inRound)
		{
			if (canShoot)
			{
				float angle = (Mathf.Atan2(Random.Range(0f, 2 * Mathf.PI), Random.Range(0f, 2 * Mathf.PI)) * Mathf.Rad2Deg);
				Quaternion q = Quaternion.AngleAxis(Random.Range(0f, 360), Vector3.down);
				transform.rotation = Quaternion.Slerp(transform.rotation, q, 1f);

				shoot();
				canShoot = false;
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
		if (shootAnim)
		{
			attackAnimator.SetTrigger("fire");

		}
		canShoot = false;
		Instantiate(bullet, shootSpot1.position, shootSpot1.rotation);
		if (tripleCannon)
		{
			Instantiate(bullet, shootSpot2.position, shootSpot2.rotation);
			if (shootSpot3 != null)
			{
				Instantiate(bullet, shootSpot3.position, shootSpot3.rotation);
				if (shootSpot4 != null)
				{
					Instantiate(bullet, shootSpot4.position, shootSpot4.rotation);
					if (shootSpot5 != null)
					{

						Instantiate(bullet, shootSpot5.position, shootSpot5.rotation);
						if (shootSpot6 != null)
						{
							Instantiate(bullet, shootSpot6.position, shootSpot6.rotation);
							Instantiate(bullet, shootSpot7.position, shootSpot7.rotation);
							Instantiate(bullet, shootSpot8.position, shootSpot8.rotation);
						}
					}
				}
			}

		}
		StartCoroutine(Reload());

	}


	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
