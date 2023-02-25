using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceFloorColorChanger : MonoBehaviour
{
    private MeshRenderer mr;
    public float timer = 0.5f;
    public float maxTime = 0.5f;
    public Material[] floorMaterials;
    void Start()
    {
        mr = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = maxTime;
            int ran = Random.Range(0, 7);
            mr.material = floorMaterials[ran];
        }
    }
}
