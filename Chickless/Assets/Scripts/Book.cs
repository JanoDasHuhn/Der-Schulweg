using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject image;
    public GameObject book;

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
                book.SetActive(true);


            }
            else
            {
                book.SetActive(false);
            }


        }


    }
}
