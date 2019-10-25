using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //ball to move towards
    GameObject dustBallTarget;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float turnSpeed = 45.0f;
    [SerializeField] Transform target;

    private void Awake()
    {
        dustBallTarget = GameObject.FindGameObjectWithTag("Dustball");
        target = dustBallTarget.transform;
    }
    private void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        //rotate the object left with the "a" key and right with the "d" key
        //transform.Rotate(Vector3.up, turnSpeed * 1 * Time.deltaTime);
    }

    public void FindDustball()
    {
        dustBallTarget = GameObject.FindGameObjectWithTag("Dustball");
    }


    //if there are no balls on the ground, move towards the player
}
