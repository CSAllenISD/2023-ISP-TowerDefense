using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  using UnityEngine.UI;
  public class dropTowers : MonoBehaviour
  {
      public Camera nonVRCamera;
      public GameObject tower1;
      public GameObject tower1ghost;
      public MeshRenderer ghost1Radius;
      public GameObject tower2;
    public MeshRenderer ghost2Radius;
    public GameObject tower3;
     public GameObject tower4;
     public GameObject tower4ghost;
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
    public bool superCanPlace;
     public Material[] ghostMaterials;
    public Transform RotationPlacement;
    //  public selectScript idk;
     playerStats playerStats;
     void Start()
     {
        RotationPlacement = tower1.transform;
      GameObject scriptthing = GameObject.FindWithTag("statistics");
         playerStats = scriptthing.GetComponent<playerStats>();
     //   Vector3 rot = tower1.transform.rotation.eulerAngles;
     //   rot = new Vector3(rot.x, rot.y + 180, rot.z);
       // RotationPlacement.rotation = Quaternion.Euler(rot);
    }
    void Update()
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
            RaycastHit hoat;
            Ray roya = nonVRCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(roya, out hoat,  1000f, ~IgnoreMe))
            {
                if (hoat.transform.name == "floor")
                {
                    tower3ghost.SetActive(true);
                    tower3ghost.transform.position = hoat.point;
                    //              SpriteRenderer spriteR = tower3ghost.GetComponent<SpriteRenderer>();
                    //  spriteR.color = Color.white;
                }
                if (hoat.transform.name != "floor")
                {
                    tower3ghost.SetActive(true);
                    //  tower3ghost.transform.position = hoat.point;
                    //  SpriteRenderer spriteR = tower3ghost.GetComponent<SpriteRenderer>();
                    // spriteR.color = Color.red;
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
            RaycastHit howat;
            Ray roaya = nonVRCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(roaya, out howat,  1000f, ~IgnoreMe))
            {
                if (howat.transform.name == "floor")
                {
                    tower4ghost.SetActive(true);
                    tower4ghost.transform.position = howat.point;
                    //                SpriteRenderer spriteR = tower4ghost.GetComponent<SpriteRenderer>();
                    //   spriteR.color = Color.white;
                }
                if (howat.transform.name != "floor")
                {
                    tower4ghost.SetActive(true);
                    //   tower4ghost.transform.position = howat.point;
                    //   SpriteRenderer spriteR = tower4ghost.GetComponent<SpriteRenderer>();
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
     if (Physics.Raycast(rey, out het,  1000f, ~IgnoreMe))
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
        } else {
            superCanPlace = false;
        }
        if (superCanPlace)
        {
            ghost1Radius.material = ghostMaterials[1];
        } else {
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
               //             if (idk != null)
              //    {
             //     idk.deselect();
             //        
              //       }
              RaycastHit hen;
              Ray ren = nonVRCamera.ScreenPointToRay(Input.mousePosition);
              if (Physics.Raycast(ren, out hen,  1000f, ~IgnoreMe))
                {
                           if (hen.transform.tag == "tower" || hen.transform.tag == "temple")
                  {
                //           idk = hen.transform.gameObject.GetComponent<selectScript>();
                //          idk.select();
                  }
                  }
                  }
         if (Input.GetMouseButtonDown(0) && TowerNumber != 0)
          {
              RaycastHit hit;
              Ray ray = nonVRCamera.ScreenPointToRay(Input.mousePosition);
  
              if (Physics.Raycast(ray, out hit, 1000f, ~IgnoreMe))
              {


                  if (hit.transform.name == "floor")
                  {
                 // if (idk != null)
               //   {
               //   idk.deselect();
               //      }
                    if (TowerNumber == 1 && superCanPlace == true)
                    {

                        GameObject towers = Instantiate(tower1, hit.point, RotationPlacement.rotation);
                        towers.SetActive(true);
                        playerStats.addCash(-215);
                        superCanPlace = false;
                      TowerNumber = 0;
                  }
                                      if (TowerNumber == 2 && superCanPlace == true)
                    {
                      GameObject towers = Instantiate(tower2, hit.point, RotationPlacement.rotation);
                        towers.SetActive(true);
                      playerStats.addCash(-250);
                      TowerNumber = 0;

                  }
                  if (TowerNumber == 3)
                    {
                        GameObject towers = Instantiate(tower3, hit.point, Quaternion.identity);
                        towers.SetActive(true);
                        TowerNumber = 0;
                  }
                  if (TowerNumber == 4)
                    {
                        GameObject towers = Instantiate(tower4, hit.point, Quaternion.identity);
                        towers.SetActive(true);
                        TowerNumber = 0;
                  }
                  }
              }
          }
      }

      public void changetothing(int number)
      {
      if (TowerNumber == number)
      {
       TowerNumber = 0;
	  } else {
       TowerNumber = number;
	  }
      }






      
  }