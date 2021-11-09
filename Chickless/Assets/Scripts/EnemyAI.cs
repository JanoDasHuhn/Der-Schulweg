
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public Vector2 target2;

    public AIDestinationSetter ai;

    public Transform target = null;
    public  float distanceTreshold = 10;
    
    public Transform normalroom;
   
    public Animator anim;
    
    
    //Enums für den Status des Gegners
    public enum AIState
    {
        idle,chasing
    }
    
    public AIState aIState = AIState.idle;

    
   
    private void Start()

    {
        print(normalroom.worldToLocalMatrix);
        
        StartCoroutine(Think());
        target = GameObject.FindGameObjectWithTag("Player").transform;


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
            switch (aIState)
            {
                //Der code ist selbsterklärend
                case AIState.idle:
                    anim.SetBool("isAngry", false);
                    float dist = Vector2.Distance(target.position, transform.position);
                    ai.SetTarget(normalroom);
                    if(dist < distanceTreshold)
                    {
                        aIState = AIState.chasing;
                    }
                    
                    break;
                case AIState.chasing:
                    anim.SetBool("isAngry", true);
                    dist = Vector2.Distance(target.position, transform.position);
                     if(dist > distanceTreshold)
                    {
                        aIState = AIState.idle;
                    }
                    ai.SetTarget(target);
                    
                   

                    break;
                default:
                    break;
            }
           
            yield return new WaitForSeconds(1);
        }
    }
    

}
