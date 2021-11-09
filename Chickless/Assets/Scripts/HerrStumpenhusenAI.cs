using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HerrStumpenhusenAI : MonoBehaviour
{
    // Start is called before the first frame update
    
    public AIDestinationSetter ai;

  
    public float distanceTreshold = 10;

    

    public Animator anim;
    public Transform[] checkpoints;


    //Enums für den Status des Gegners
    



    private void Start()

    {
        

        StartCoroutine(Think());
       


    }

    private void Update()
    {
        //Gun ist keine Schuswaffe sondern ein anderes wurfgeschoss

        //Rotation von der "Waffe"
        if (PlayerController.instance.gameObject.transform.position.x > transform.position.x)
        {

            transform.localScale = Vector2.one;
        }
        else
        {

            transform.localScale = new Vector2(-1f, 1f);

        }
    }

    IEnumerator Think()
    {
        while (true)
        {
            Transform nextpos = checkpoints[Random.Range(0, 4)];
            ai.SetTarget(nextpos);
            yield return new WaitForSeconds(3);

        }
    }


}
