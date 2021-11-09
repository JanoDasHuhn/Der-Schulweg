using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaschbeckenCollider : MonoBehaviour
{
    public GameObject image;
    public Animator anim;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Player")
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
    public void Update()
    {
       
    }


    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (anim.GetBool("isinUse") == false)
            {
                anim.SetBool("isinUse", true);
                StartCoroutine(Warten());

            }


        }


    }
    IEnumerator Warten()
    {
        

       
        yield return new WaitForSeconds(1);
        anim.SetBool("isinUse", false);

        
    }

}
