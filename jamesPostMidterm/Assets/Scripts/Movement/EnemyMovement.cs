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

    private void Start()
    {
        //destroy the enemy after a set period of time
        DestroyAfterTime();
    }
    private void Update()
    {
        //if target is null then run FindDustball() method
        if(!target)
        {
            FindDustball();
        }
        
        float step = speed * Time.deltaTime; 
        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    public void FindDustball()
    {
        //if FindDustball() *can* find a dustBall target:
        try
        {
            //assign dustBallTarget to a game object in the scene with the tag "Dustball"
            dustBallTarget = GameObject.FindGameObjectWithTag("Dustball");
            //assign target (transform) to the dustBallTargets transform
            target = dustBallTarget.transform;
        }

        //if FindDustball() *cannot* find a dustBall target:
        catch
        {
            //change the target to the player
            target = GameObject.FindGameObjectWithTag("Player").transform;
            Invoke("FindDustball", 3);
            //print a debug
            //Debug.Log("the player is now the target!");
        }
    }
    //destroys the enemy after a set period of time
    private void DestroyAfterTime()
    {
        Destroy(gameObject, destroyTime);
        //debug
        Debug.Log("enemy roomba should destroy");
    }
}
