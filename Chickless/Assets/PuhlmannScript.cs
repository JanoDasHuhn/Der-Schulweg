using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuhlmannScript : MonoBehaviour
{

    public AudioSource sound;
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
