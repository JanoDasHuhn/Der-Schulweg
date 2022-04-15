using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRusRoomScript : MonoBehaviour
{
    public AudioSource sound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sound.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sound.Stop();
        }
    }
}
