using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 7.5f;
    public Rigidbody2D RB;
    public GameObject impactEffect;
    public int damage = 20;
    void Start()
    {
        StartCoroutine(TodesTimer());
    }

   
    void Update()
    {
        RB.velocity = transform.right *speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other);
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        
        
        
        
    }
    IEnumerator TodesTimer()
    {
        

        
        yield return new WaitForSeconds(5);
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

        
    }
}
