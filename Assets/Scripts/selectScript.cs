using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class selectScript : MonoBehaviour
{
	public GameObject sellFX;
	public GameObject range;
	public GameObject UI;
	public GameObject TopPath;
	public GameObject BottomPath;
	public Button button1;
	public Button button2;
	public int pricetop = 0;
	public int pricebottom = 0;
	public int sellValue;
	public playerStats pstats;
	public AudioSource selectSound;
	public AudioSource sellSound;
	void Start()
	{
		selectSound = GameObject.FindGameObjectsWithTag("selectEffect")[0].GetComponent<AudioSource>();
		sellSound = GameObject.FindGameObjectsWithTag("sellEffect")[0].GetComponent<AudioSource>();
		GameObject[] stats = GameObject.FindGameObjectsWithTag("statistics");
		pstats = stats[0].GetComponent<playerStats>();
	}
	void Update()
	{
		int amountOfMoneyThatYouHaveAtThisMoment = playerStats.cash;
		if (TopPath == null || amountOfMoneyThatYouHaveAtThisMoment < pricetop)
		{
			button1.interactable = false;
		}
		if (BottomPath == null || amountOfMoneyThatYouHaveAtThisMoment < pricebottom)
		{
			button2.interactable = false;
		}

		if (TopPath != null && amountOfMoneyThatYouHaveAtThisMoment >= pricetop)
		{
			button1.interactable = true;
		}
		if (BottomPath != null && amountOfMoneyThatYouHaveAtThisMoment >= pricebottom)
		{
			button2.interactable = true;
		}
	}

	public void select()
	{
		selectSound.Play();
		range.SetActive(true);
		StartCoroutine(selectThing());
	}
	public void deselect()
	{

		range.SetActive(false);
		StartCoroutine(deselectThing());
	}

	public void upgrade()
	{
		selectSound.Play();
		Debug.Log("upgraded");
		pstats.addCash(-pricetop);
		Instantiate(TopPath, transform.position, transform.rotation);
		Destroy(gameObject);
	}
	public void upgrade2()
	{
		selectSound.Play();
		Debug.Log("upgraded");
		pstats.addCash(-pricebottom);
		Instantiate(BottomPath, transform.position, transform.rotation);
		Destroy(gameObject);
	}
	public void sell()
    {
		sellSound.Play();
		pstats.addCash(sellValue);
		Instantiate(sellFX, transform.position, transform.rotation);
		Destroy(gameObject);
    }
	IEnumerator deselectThing()
	{
		yield return new WaitForSeconds(0.1f);
		UI.SetActive(false);
	}
	IEnumerator selectThing()
	{
		yield return new WaitForSeconds(0.1f);
		UI.SetActive(true);
	}



}
