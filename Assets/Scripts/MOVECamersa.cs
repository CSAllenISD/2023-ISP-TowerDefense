using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVECamersa : MonoBehaviour
{
    public GameObject cameraaa;
    public Transform[] tPositions;
    public int positionCounter;
    public float slerpp;
    public GameObject[] levelButtons;
    void Start()
    {
        positionCounter = 0;
    }
    void Update()
    {

        Vector3 newPos = new Vector3(tPositions[positionCounter].position.x, tPositions[positionCounter].position.y, tPositions[positionCounter].position.z);
        cameraaa.transform.position = Vector3.Lerp(cameraaa.transform.position, newPos, Time.deltaTime * slerpp);
    }
    public void switchCamera(int val)
    {
        if (val == 1 && positionCounter == 2)
        {
            positionCounter = 0;
        } else if (val == -1 && positionCounter == 0)
        {
            positionCounter = 2;
        } else
        {
            positionCounter += val;
        }
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i != positionCounter)
            {
                levelButtons[i].SetActive(false);
            } else
            {
                levelButtons[i].SetActive(true);
            }
        }
    }
}
