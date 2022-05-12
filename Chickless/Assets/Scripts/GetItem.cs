using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetItem : MonoBehaviour
{
    public ZGController zg;
    public Text zgCounter;
    public int zeugnisseAlready;
    public void Awake()
    {
       

    }
    private void Start()

    {
        zgCounter.text = Zeugnisse.zeugnisse + "/3";
        if(Zeugnisse.zeugnisse >= zeugnisseAlready)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Zeugnisse.addZeug();
            print(Zeugnisse.zeugnisse);
            zgCounter.text = Zeugnisse.zeugnisse + "/3";
            if(Zeugnisse.zeugnisse == 3)
            {
                SceneManager.LoadScene("WinScreen");
            }
            Destroy(this.gameObject);
        }
      
    }
}
