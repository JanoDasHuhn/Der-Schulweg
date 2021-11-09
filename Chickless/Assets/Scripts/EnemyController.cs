using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D RB;
    public float moveSpeed;

    public float rangeToChasePlayer;
    private Vector3 moveDirection;

    public Animator anim;
    public int health = 150;

    public GameObject[] deathSplatters;
    public GameObject hitEffect;

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
       if(skin.isVisible && PlayerController.instance.gameObject.activeInHierarchy) 
        {
            print("Spieler gefunden");
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToChasePlayer)
            {
                moveDirection = PlayerController.instance.transform.position - transform.position;
                print("Jage Spieler");
            }
            else
            {
                moveDirection = Vector3.zero;
            }
            if (PlayerController.instance.gameObject.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(-1f, 1f);
                gun.localScale = new Vector2(-6f, -6f);
            }
            else
            {
                transform.localScale = Vector2.one;
                gun.localScale = new Vector2(6f, 6f);
            }
            moveDirection.Normalize();
            RB.velocity = moveDirection * moveSpeed;

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
            RotateTorwards(PlayerController.instance.gameObject.transform.position);
            if (moveDirection != Vector3.zero)
            {
                anim.SetBool("isMoving", true);

            }
            else
            {
                anim.SetBool("isMoving", false);
            }
            //
        }
        else
        {
            RB.velocity = Vector2.zero;
            
        }
    }


    private void RotateTorwards(Vector2 target)
    {
        Vector3 screenPoint = Cam.WorldToScreenPoint(transform.localPosition);
        
        var offset = 180f;
        Vector2 direction = target - (Vector2)gun.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.Euler(Vector3.forward * (angle + offset)) ;
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;
        Instantiate(hitEffect, transform.position, transform.rotation);
        if(health <= 0)
        {
            Destroy(gameObject);
            int selectedSplatter = UnityEngine.Random.Range(0, deathSplatters.Length);
            int rotation = UnityEngine.Random.Range(0, 4);
            Instantiate(deathSplatters[selectedSplatter],transform.position,Quaternion.Euler(0f,0f,rotation * 90));

        }
    }
    
}
