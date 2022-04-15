using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScript : MonoBehaviour
{
    public GameObject image;
    public AudioSource sound;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            image.SetActive(true);

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            image.SetActive(false);

        }

    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (PlayerController.instance.hasBook == false)
            {
                sound.Play();


            }
            


        }


    }
}
