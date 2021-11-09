using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BrokenPeaces : MonoBehaviour
{
    public float moveSpeed = 5;
    private Vector3 moveDirection;

    public float deceleration = 5;
    public float lifetime = 3f;

    public SpriteRenderer sr;
    public float fadeSpeed = 2.5f;

    void Start()
    {
        moveDirection.x = Random.Range(-moveSpeed, moveSpeed);
        moveDirection.y = Random.Range(-moveSpeed, moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * Time.deltaTime;

        moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, deceleration * Time.deltaTime);

        lifetime -= Time.deltaTime;
        if(lifetime < 0)
        {

            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, Mathf.MoveTowards(sr.color.a, 0f, fadeSpeed * Time.deltaTime));
            if(sr.color.a == 0f)
            {

                Destroy(gameObject);
            }
           ;
        }
    }
}
