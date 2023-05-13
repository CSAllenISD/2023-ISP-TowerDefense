using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  using UnityEngine.UI;
using UnityEngine.EventSystems;
public class dropTowers : MonoBehaviour
  {
    public GameObject pauseMenu;
      public Camera nonVRCamera;
      public GameObject tower1;
      public GameObject tower1ghost;
      public MeshRenderer ghost1Radius;
      public GameObject tower2;
    public MeshRenderer ghost2Radius;
    public GameObject tower3;
    public MeshRenderer ghost3Radius;
    public GameObject tower4;
     public GameObject tower4ghost;
    public MeshRenderer ghost4Radius;
    public GameObject tower5;
    public GameObject tower5ghost;
    public MeshRenderer ghost5Radius;
    public GameObject tower6;
    public GameObject tower6ghost;
    public MeshRenderer ghost6Radius;
    public GameObject tower7;
    public GameObject tower7ghost;
    public MeshRenderer ghost7Radius;
    public GameObject tower3ghost;
      public GameObject tower2ghost;
      public int TowerNumber;
      private Vector3 mousePosition;
      public float moveSpeed = 1f;
      public Transform ghostArea;
     public LayerMask IgnoreMe;
     public bool canPlace;
     public float placeRadius;
    public float placeRadius2;
    public float placeRadius5;
    public float placeRadius6;
    public float placeRadius7;
    public bool superCanPlace;
     public Material[] ghostMaterials;
    public Transform RotationPlacement;
      public selectScript idk;
    public float yOffSetTower1;
    public float yOffSetTower3;
    public float yOffSetTower4;
    public float yOffSetTower5;
    public float yOffSetTower6;
    public float yOffSetTower7;
    public int t1Cost;
    public int t2Cost;
    public int t3Cost;
    public int t4Cost;
    public int t5Cost;
    public int t6Cost;
    public int t7Cost;
    playerStats playerStats;
    public AudioSource selectSound;
    void Start()
     {
        selectSound = GameObject.FindGameObjectsWithTag("selectEffect")[0].GetComponent<AudioSource>();
        RotationPlacement = tower1.transform;
      GameObject scriptthing = GameObject.FindWithTag("statistics");
         playerStats = scriptthing.GetComponent<playerStats>();
     //   Vector3 rot = tower1.transform.rotation.eulerAngles;
     //   rot = new Vector3(rot.x, rot.y + 180, rot.z);
       // RotationPlacement.rotation = Quaternion.Euler(rot);
    }
    void Update()
    {
        if (!pauseMenu.activeSelf)
        {

            if (TowerNumber != 2)
            {
                if (tower2ghost.activeSelf)
                {
                    tower2ghost.transform.position = ghostArea.position;
                }
                tower2ghost.SetActive(false);
            }

            if (TowerNumber == 2)
            {
                tower2ghost.SetActive(true);
                RaycastHit het;
                Ray rey = nonVRCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rey, out het, 1000f, ~IgnoreMe))
                {
                    if (het.transform.name == "floor")
                    {
                        tower2ghost.SetActive(true);
                        tower2ghost.transform.position = het.point;
                        canPlace = true;
                        Collider[] hitColliders = Physics.OverlapSphere(het.point, placeRadius2);

                        foreach (var hitCollider in hitColliders)
                        {
                            if (hitCollider.transform.gameObject.tag == "tower")
                            {
                                canPlace = false;
                            }
                        }
                        if (canPlace == true)
                        {
                            superCanPlace = true;
                        }
                        else
                        {
                            superCanPlace = false;
                        }
                        if (superCanPlace)
                        {
                            ghost2Radius.material = ghostMaterials[1];
                        }
                        else
                        {
                            ghost2Radius.material = ghostMaterials[0];
                        }
                        //                 SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.white;
                    }
                    if (het.transform.name != "floor")
                    {
                        tower2ghost.SetActive(true);
                        tower2ghost.transform.position = het.point;
                        ghost2Radius.material = ghostMaterials[0];
                        //   SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.red;
                    }
                }


            }



            /*    if (TowerNumber != 2)
                {
                if (tower2ghost.activeSelf)
              {
              tower2ghost.transform.position = ghostArea.position;
              }
                    tower2ghost.SetActive(false);
                }
                if (TowerNumber == 2)
                {
                    RaycastHit hot;
                    Ray roy = nonVRCamera.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(roy, out hot, 1000f, ~IgnoreMe))
                    {
                        if (hot.transform.name == "floor")
                        {
                            tower2ghost.SetActive(true);
                            tower2ghost.transform.position = hot.point;
                            //    SpriteRenderer spriteR = tower2ghost.GetComponent<SpriteRenderer>();
                            //   spriteR.color = Color.white;
                        }
                        if (hot.transform.name != "floor")
                        {
                            tower2ghost.SetActive(true);
                            //   tower2ghost.transform.position = hot.point;
                            //   SpriteRenderer spriteR = tower2ghost.GetComponent<SpriteRenderer>();
                            //   spriteR.color = Color.red;
                        }
                    }
                } */


            if (TowerNumber != 3)
            {
                if (tower3ghost.activeSelf)
                {
                    tower3ghost.transform.position = ghostArea.position;
                }
                tower3ghost.SetActive(false);
            }

            if (TowerNumber == 3)
            {
                tower3ghost.SetActive(true);
                RaycastHit het;
                Ray rey = nonVRCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rey, out het, 1000f, ~IgnoreMe))
                {
                    if (het.transform.name == "floor")
                    {
                        tower3ghost.SetActive(true);
                        tower3ghost.transform.position = het.point;
                        canPlace = true;
                        Collider[] hitColliders = Physics.OverlapSphere(het.point, placeRadius2);

                        foreach (var hitCollider in hitColliders)
                        {
                            if (hitCollider.transform.gameObject.tag == "tower" || hitCollider.transform.gameObject.tag == "obstacle")
                            {
                                canPlace = false;
                            }
                        }
                        if (canPlace == true)
                        {
                            superCanPlace = true;
                        }
                        else
                        {
                            superCanPlace = false;
                        }
                        if (superCanPlace)
                        {
                            ghost3Radius.material = ghostMaterials[1];
                        }
                        else
                        {
                            ghost3Radius.material = ghostMaterials[0];
                        }
                        //                 SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.white;
                    }
                    if (het.transform.name != "floor")
                    {
                        tower3ghost.SetActive(true);
                        tower3ghost.transform.position = het.point;
                        ghost3Radius.material = ghostMaterials[0];
                        //   SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.red;
                    }
                }


            }




            if (TowerNumber != 4)
            {
                if (tower4ghost.activeSelf)
                {
                    tower4ghost.transform.position = ghostArea.position;
                }
                tower4ghost.SetActive(false);
            }

            if (TowerNumber == 4)
            {
                tower4ghost.SetActive(true);
                RaycastHit het;
                Ray rey = nonVRCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rey, out het, 1000f, ~IgnoreMe))
                {
                    if (het.transform.name == "floor")
                    {
                        tower4ghost.SetActive(true);
                        tower4ghost.transform.position = het.point;
                        canPlace = true;
                        Collider[] hitColliders = Physics.OverlapSphere(het.point, placeRadius2);

                        foreach (var hitCollider in hitColliders)
                        {
                            if (hitCollider.transform.gameObject.tag == "tower")
                            {
                                canPlace = false;
                            }
                        }
                        if (canPlace == true)
                        {
                            superCanPlace = true;
                        }
                        else
                        {
                            superCanPlace = false;
                        }
                        if (superCanPlace)
                        {
                            ghost4Radius.material = ghostMaterials[1];
                        }
                        else
                        {
                            ghost4Radius.material = ghostMaterials[0];
                        }
                        //                 SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.white;
                    }
                    if (het.transform.name != "floor")
                    {
                        tower4ghost.SetActive(true);
                        tower4ghost.transform.position = het.point;
                        ghost4Radius.material = ghostMaterials[0];
                        //   SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.red;
                    }
                }


            }





            if (TowerNumber != 5)
            {
                if (tower5ghost.activeSelf)
                {
                    tower5ghost.transform.position = ghostArea.position;
                }
                tower5ghost.SetActive(false);
            }

            if (TowerNumber == 5)
            {
                tower5ghost.SetActive(true);
                RaycastHit het;
                Ray rey = nonVRCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rey, out het, 1000f, ~IgnoreMe))
                {
                    if (het.transform.name == "floor")
                    {
                        tower5ghost.SetActive(true);
                        tower5ghost.transform.position = het.point;
                        canPlace = true;
                        Collider[] hitColliders = Physics.OverlapSphere(het.point, placeRadius5);

                        foreach (var hitCollider in hitColliders)
                        {
                            if (hitCollider.transform.gameObject.tag == "tower")
                            {
                                canPlace = false;
                            }
                        }
                        if (canPlace == true)
                        {
                            superCanPlace = true;
                        }
                        else
                        {
                            superCanPlace = false;
                        }
                        if (superCanPlace)
                        {
                            ghost5Radius.material = ghostMaterials[1];
                        }
                        else
                        {
                            ghost5Radius.material = ghostMaterials[0];
                        }
                        //                 SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.white;
                    }
                    if (het.transform.name != "floor")
                    {
                        tower5ghost.SetActive(true);
                        tower5ghost.transform.position = het.point;
                        ghost5Radius.material = ghostMaterials[0];
                        //   SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.red;
                    }
                }


            }



            if (TowerNumber != 6)
            {
                if (tower6ghost.activeSelf)
                {
                    tower6ghost.transform.position = ghostArea.position;
                }
                tower6ghost.SetActive(false);
            }

            if (TowerNumber == 6)
            {
                tower6ghost.SetActive(true);
                RaycastHit het;
                Ray rey = nonVRCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rey, out het, 1000f, ~IgnoreMe))
                {
                    if (het.transform.name == "floor")
                    {
                        tower6ghost.SetActive(true);
                        tower6ghost.transform.position = het.point;
                        canPlace = true;
                        Collider[] hitColliders = Physics.OverlapSphere(het.point, placeRadius6);

                        foreach (var hitCollider in hitColliders)
                        {
                            if (hitCollider.transform.gameObject.tag == "tower")
                            {
                                canPlace = false;
                            }
                        }
                        if (canPlace == true)
                        {
                            superCanPlace = true;
                        }
                        else
                        {
                            superCanPlace = false;
                        }
                        if (superCanPlace)
                        {
                            ghost6Radius.material = ghostMaterials[1];
                        }
                        else
                        {
                            ghost6Radius.material = ghostMaterials[0];
                        }
                        //                 SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.white;
                    }
                    if (het.transform.name != "floor")
                    {
                        tower6ghost.SetActive(true);
                        tower6ghost.transform.position = het.point;
                        ghost6Radius.material = ghostMaterials[0];
                        //   SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.red;
                    }
                }


            }




            if (TowerNumber != 7)
            {
                if (tower7ghost.activeSelf)
                {
                    tower7ghost.transform.position = ghostArea.position;
                }
                tower7ghost.SetActive(false);
            }
            if (TowerNumber == 7)
            {
                tower7ghost.SetActive(true);
                RaycastHit het;
                Ray rey = nonVRCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rey, out het, 1000f, ~IgnoreMe))
                {
                    if (het.transform.name == "floor")
                    {
                        tower7ghost.SetActive(true);
                        tower7ghost.transform.position = het.point;
                        canPlace = true;
                        Collider[] hitColliders = Physics.OverlapSphere(het.point, placeRadius7);

                        foreach (var hitCollider in hitColliders)
                        {
                            if (hitCollider.transform.gameObject.tag == "tower")
                            {
                                canPlace = false;
                            }
                        }
                        if (canPlace == true)
                        {
                            superCanPlace = true;
                        }
                        else
                        {
                            superCanPlace = false;
                        }
                        if (superCanPlace)
                        {
                            ghost7Radius.material = ghostMaterials[1];
                        }
                        else
                        {
                            ghost7Radius.material = ghostMaterials[0];
                        }
                        //                 SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.white;
                    }
                    if (het.transform.name != "floor")
                    {
                        tower7ghost.SetActive(true);
                        tower7ghost.transform.position = het.point;
                        ghost7Radius.material = ghostMaterials[0];
                        //   SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.red;
                    }
                }


            }








            if (TowerNumber != 1)
            {
                if (tower1ghost.activeSelf)
                {
                    tower1ghost.transform.position = ghostArea.position;
                }
                tower1ghost.SetActive(false);
            }

            if (TowerNumber == 1)
            {
                tower1ghost.SetActive(true);
                RaycastHit het;
                Ray rey = nonVRCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rey, out het, 1000f, ~IgnoreMe))
                {
                    if (het.transform.name == "floor")
                    {
                        tower1ghost.SetActive(true);
                        tower1ghost.transform.position = het.point;
                        canPlace = true;
                        Collider[] hitColliders = Physics.OverlapSphere(het.point, placeRadius);

                        foreach (var hitCollider in hitColliders)
                        {
                            if (hitCollider.transform.gameObject.tag == "tower")
                            {
                                canPlace = false;
                            }
                        }
                        if (canPlace == true)
                        {
                            superCanPlace = true;
                        }
                        else
                        {
                            superCanPlace = false;
                        }
                        if (superCanPlace)
                        {
                            ghost1Radius.material = ghostMaterials[1];
                        }
                        else
                        {
                            ghost1Radius.material = ghostMaterials[0];
                        }
                        //                 SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.white;
                    }
                    if (het.transform.name != "floor")
                    {
                        tower1ghost.SetActive(true);
                        tower1ghost.transform.position = het.point;
                        ghost1Radius.material = ghostMaterials[0];
                        //   SpriteRenderer spriteR = tower1ghost.GetComponent<SpriteRenderer>();
                        //   spriteR.color = Color.red;
                    }
                }


            }
            if (Input.GetMouseButtonDown(0) && TowerNumber == 0)
            {
                       
                RaycastHit hen;
                Ray ren = nonVRCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ren, out hen, 1000f))
                {
                    if (!EventSystem.current.IsPointerOverGameObject() && idk != null)
                    {
                        idk.deselect();

                       }
                    if (hen.transform.tag == "tower" || hen.transform.tag == "temple")
                    {
                                   idk = hen.transform.gameObject.GetComponent<selectScript>();
                                  idk.select();
                    }
                }
            }
            if (Input.GetMouseButtonDown(0) && TowerNumber != 0)
            {
                RaycastHit hit;
                Ray ray = nonVRCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 1000f))
                {


                    if (hit.transform.name == "floor")
                    {
                         if (idk != null)
                           {
                           idk.deselect();
                              }
                        if (TowerNumber == 1 && superCanPlace == true)
                        {
                            selectSound.Play();
                            Vector3 placePosition = new Vector3(hit.point.x, hit.point.y + yOffSetTower1, hit.point.z);
                            GameObject towers = Instantiate(tower1, placePosition, RotationPlacement.rotation);
                            towers.SetActive(true);
                            playerStats.addCash(-t1Cost);
                            superCanPlace = false;
                            TowerNumber = 0;
                        }
                        if (TowerNumber == 2 && superCanPlace == true)
                        {
                            selectSound.Play();
                            GameObject towers = Instantiate(tower2, hit.point, RotationPlacement.rotation);
                            towers.SetActive(true);
                            playerStats.addCash(-t2Cost);
                            TowerNumber = 0;

                        }
                        if (TowerNumber == 3)
                        {
                            selectSound.Play();
                            Vector3 placePosition = new Vector3(hit.point.x, hit.point.y + yOffSetTower3, hit.point.z);
                            GameObject towers = Instantiate(tower3, placePosition, RotationPlacement.rotation);
                            towers.SetActive(true);
                            playerStats.addCash(-t3Cost);
                            TowerNumber = 0;
                        }
                        if (TowerNumber == 4)
                        {
                            selectSound.Play();
                            Vector3 placePosition = new Vector3(hit.point.x, hit.point.y + yOffSetTower4, hit.point.z);
                            GameObject towers = Instantiate(tower4, placePosition, RotationPlacement.rotation);
                            towers.SetActive(true);
                            playerStats.addCash(-t4Cost);
                            TowerNumber = 0;
                        }
                        if (TowerNumber == 5)
                        {
                            selectSound.Play();
                            Vector3 placePosition = new Vector3(hit.point.x, hit.point.y + yOffSetTower5, hit.point.z);
                            GameObject towers = Instantiate(tower5, placePosition, RotationPlacement.rotation);
                            towers.SetActive(true);
                            playerStats.addCash(-t5Cost);
                            TowerNumber = 0;
                        }
                        if (TowerNumber == 6)
                        {
                            selectSound.Play();
                            Vector3 placePosition = new Vector3(hit.point.x, hit.point.y + yOffSetTower6, hit.point.z);
                            GameObject towers = Instantiate(tower6, placePosition, RotationPlacement.rotation);
                            towers.SetActive(true);
                            playerStats.addCash(-t6Cost);
                            TowerNumber = 0;
                        }
                        if (TowerNumber == 7)
                        {
                            selectSound.Play();
                            Vector3 placePosition = new Vector3(hit.point.x, hit.point.y + yOffSetTower7, hit.point.z);
                            GameObject towers = Instantiate(tower7, placePosition, RotationPlacement.rotation);
                            towers.SetActive(true);
                            playerStats.addCash(-t7Cost);
                            TowerNumber = 0;
                        }
                    }
                }
            }
        }
    }
      public void changetothing(int number)
      {
        selectSound.Play();
        if (TowerNumber == number)
      {
       TowerNumber = 0;
	  } else {
       TowerNumber = number;
	  }
      }






      
  }