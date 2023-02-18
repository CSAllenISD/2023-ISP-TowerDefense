using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuallySpawnEnemy : MonoBehaviour
{
    public GameObject testEnemy;
    public Transform spawnTransform;
    public void spawnTestEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(testEnemy, spawnTransform.position, testEnemy.transform.rotation);
        }
    }
}
