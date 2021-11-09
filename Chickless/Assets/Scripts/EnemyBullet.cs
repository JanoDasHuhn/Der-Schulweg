using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        
    }
    private void OnTriggerEnter2D(Collider2D other )
    {
        print("hit");
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
       
        
    }
    private void OnBecameInvisible()
    {

        Destroy(gameObject);
    }
}
