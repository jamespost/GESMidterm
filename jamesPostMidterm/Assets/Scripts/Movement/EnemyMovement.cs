using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //ball to move towards
    private GameObject dustBallTarget;
    //transform to move towards
    private Transform target;
    //movement fields
    [SerializeField] float speed = 1.0f;
    [SerializeField] float turnSpeed = 45.0f;
    [SerializeField] int destroyTime = 10;
    public bool canMove = true;

    private void Start()
    {
        //destroy the enemy after a set period of time
        DestroyAfterTime();
    }
    private void Update()
    {
        //if target is null then run FindTarget() method
        if (!target)
        {
            FindTarget();
        }

        if (canMove)
        {
            float step = speed * Time.deltaTime;
            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        
    }

    public void FindTarget()
    {        
        //target the player
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        //print a debug
        //Debug.Log("the player is now the target!");
        
    }
    //destroys the enemy after a set period of time
    private void DestroyAfterTime()
    {
        Destroy(gameObject, destroyTime);
        //debug
        Debug.Log("enemy roomba should destroy");
    }
}
