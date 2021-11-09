using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetItem : MonoBehaviour
{
    public ZGController zg;
    
    public void Awake()
    {
       

    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Zeugnisse.addZeug();
            print(Zeugnisse.zeugnisse);
            Destroy(this.gameObject);
        }
      
    }
}
