using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerrPuhlmannCollider : MonoBehaviour
{
    public GameObject puhlmann;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            puhlmann.SetActive(true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            puhlmann.SetActive(false);
        }
    }
}
