using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    //ball to move towards
    private GameObject dustBallTarget;
    //transform to move towards
    private Transform target;
    //movement fields
    [SerializeField] float speed = 1.0f;
    [SerializeField] float turnSpeed = 45.0f;


    private void Update()
    {
        //if target is null then run FindDustball() method
        if (!target)
        {
            FindPlayer();
        }

        float step = speed * Time.deltaTime;
        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        //rotate towards the player
        transform.rotation = Quaternion.Inverse(target.rotation);
    }

    public void FindPlayer()
    {        
        {
            //target the player
            target = GameObject.FindGameObjectWithTag("Player").transform;
            //Invoke("FindDustball", 3);
            //print a debug
            //Debug.Log("the player is now the target!");
        }
    }
}
