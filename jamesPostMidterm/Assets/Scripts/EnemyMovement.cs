using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //ball to move towards
    private GameObject dustBallTarget;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float turnSpeed = 45.0f;
    private Transform target;

    private void Awake()
    {
        FindDustball();    
        
    }
    private void Update()
    {
        if(!target)
        {
            FindDustball();
        }
        //rotate the object left with the "a" key and right with the "d" key
        //transform.Rotate(Vector3.up, turnSpeed * 1 * Time.deltaTime);
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    public void FindDustball()
    {
        try
        {
            dustBallTarget = GameObject.FindGameObjectWithTag("Dustball");
            target = dustBallTarget.transform;
        }
        

        catch
        {
            //change the target to the player
            target = GameObject.FindGameObjectWithTag("Player").transform;
            //print a debug
            Debug.Log("the player is now the target!");
        }
    }


    //if there are no balls on the ground, move towards the player
}
