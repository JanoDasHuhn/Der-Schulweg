using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    
   

    
    

    

    public bool shouldShoot;

    public GameObject bullet;
    public Transform firepoint;
    public float fireRate;
    private float fireCounter;

    public float shootRange = 9;

    public Transform gun;
    private Camera Cam;

    public SpriteRenderer skin;



    void Start()
    {
        Cam = Camera.main;
    }


    void Update()
    {
        RotateTorwards(PlayerController.instance.gameObject.transform.position);
        if (skin.isVisible && PlayerController.instance.gameObject.activeInHierarchy)
        {
            print("Spieler gefunden");
           
            if (PlayerController.instance.gameObject.transform.position.x > transform.position.x)
            {
                
                gun.localScale = new Vector2(6f, -6f);
            }
            else
            {
                
                gun.localScale = new Vector2(-6f, 6f);
            }
            

            if (shouldShoot && Vector3.Distance(transform.position, PlayerController.instance.transform.position) < shootRange)
            {

                fireCounter -= Time.deltaTime;
                if (fireCounter <= 0)
                {
                    fireCounter = fireRate;
                    Instantiate(bullet, firepoint.position, firepoint.rotation);

                }
            }
            //zielen
            
            
            //
        }
        
    }


    private void RotateTorwards(Vector2 target)
    {
        Vector3 screenPoint = Cam.WorldToScreenPoint(transform.localPosition);

        var offset = 0f;
        Vector2 direction = target - (Vector2)gun.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

   

}
