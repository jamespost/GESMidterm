using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private variables
    [SerializeField] float speed = 20.0f;
    [SerializeField] float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;


    // Update is called once per frame
    void Update()
    {
        //stores the return value of the horizontal input axis (by default, the horzizontal axis is controled by the "a" and "d" keys
        horizontalInput = Input.GetAxis("Horizontal");
        //stores the return value of the vertical input axis (by default, the vertical axis is controled by the "w" and "s" keys
        forwardInput = Input.GetAxis("Vertical");

        //We'll move the vehicle forward with the "w" key, and backward with the "s" key
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //rotate the player left with the "a" key and right with the "d" key
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

    }
}
