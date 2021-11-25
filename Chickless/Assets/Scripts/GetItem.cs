using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItem : MonoBehaviour
{
    public ZGController zg;
    public Text zgCounter;
    
    public void Awake()
    {
       

    }
    private void Start()
    {
        zgCounter.text = Zeugnisse.zeugnisse + "/5";
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Zeugnisse.addZeug();
            print(Zeugnisse.zeugnisse);
            zgCounter.text = Zeugnisse.zeugnisse + "/5";
            Destroy(this.gameObject);
        }
      
    }
}
