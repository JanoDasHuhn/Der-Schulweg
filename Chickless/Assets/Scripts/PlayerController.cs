using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
   
    public static PlayerController instance;
    public float MoveSpeed;
    private Vector2 moveInput;
    public bool hasBook = false;

    public Rigidbody2D RB;
    public Transform gunArm;

    private Camera Cam;

    public Animator anim;

    public GameObject bulletToFire;
    public Transform firepoint;

    public bool canShoot = true;

    public float timeBetweenShots;
    private float shotCounter;

    public SpriteRenderer skinSR;

    private float activemoveSpeed;

    public float dashSpeed = 8f, dashLenght = .5f, dashCooldown = 1f, dashInvincibility = .5f;
    private float  dashCoolCounter;
    [HideInInspector]
    public float dashCounter;


    [HideInInspector]
    public bool canMove = true;

    //Aron guck weg

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Cam = Camera.main;

        activemoveSpeed = MoveSpeed;
    }
    private void Update()
    {
        if (canMove)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            moveInput.Normalize();

            //transform.position += new Vector3(moveInput.x, moveInput.y,0f) * Time.deltaTime * MoveSpeed;
            RB.velocity = moveInput * activemoveSpeed;
            Vector3 mousePos = Input.mousePosition;
            Vector3 screenPoint = Cam.WorldToScreenPoint(transform.localPosition);

            if (mousePos.x < screenPoint.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                gunArm.localScale = new Vector3(-1f, -1f, 1f);
            }
            else
            {
                transform.localScale = Vector3.one;
                gunArm.localScale = Vector3.one;
            }




            Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            gunArm.rotation = Quaternion.Euler(0, 0, angle);

            if (moveInput != Vector2.zero)
            {
                anim.SetBool("isMoving", true);

            }
            else
            {
                anim.SetBool("isMoving", false);
            }
            if (Input.GetMouseButtonDown(0) && canShoot == true)
            {

                Instantiate(bulletToFire, firepoint.position, firepoint.rotation);
                AudioManager.instance.PlaySFX(0);
            }

            if (Input.GetMouseButton(0) && canShoot == true)
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    Instantiate(bulletToFire, firepoint.position, firepoint.rotation);
                    shotCounter = timeBetweenShots;
                    AudioManager.instance.PlaySFX(0);
                }

            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (dashCoolCounter <= 0 && dashCounter <= 0)
                {
                    activemoveSpeed = dashSpeed;
                    dashCounter = dashLenght;
                    anim.SetTrigger("dash");
                    PlayerHealthController.instance.MakeInvicible(dashInvincibility);
                }

            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("TitleScreen");
            }
            if (dashCounter > 0)
            {
                dashCounter -= Time.deltaTime;
                if (dashCounter <= 0)
                {
                    activemoveSpeed = MoveSpeed;
                    dashCoolCounter = dashCooldown;
                }
            }
            if (dashCoolCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
            }
        }
        else
        {
            RB.velocity = Vector2.zero;
            anim.SetBool("isMoving", false);
        }
    }

}
