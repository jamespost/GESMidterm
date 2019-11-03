using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private variables
    [SerializeField] float speed = 20.0f;
    [SerializeField] float turnSpeed = 45.0f;
    [SerializeField] float jumpForce;
    private float horizontalInput;
    private float forwardInput;
    private bool isOnGround = true;
    private bool hasBeenHitByEnemy = false;
    Rigidbody playerRb;
    BallSpawner bs;

    private void Start()
    {
        //initialze variables
        playerRb = GetComponent<Rigidbody>();
        bs = GameObject.Find("Floor").GetComponent<BallSpawner>();
        jumpForce = 10;             
    }

    // Update is called once per frame
    void Update()
    {
        /*normal movement*/
        //stores the return value of the horizontal input axis (by default, the horzizontal axis is controled by the "a" and "d" keys
        horizontalInput = Input.GetAxis("Horizontal");
        //stores the return value of the vertical input axis (by default, the vertical axis is controled by the "w" and "s" keys
        forwardInput = Input.GetAxis("Vertical");
        if (!hasBeenHitByEnemy)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                //We'll move the vehicle forward with the "w" key, and backward with the "s" key
                transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

                //play normal roomba movement sound
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                //rotate the player with the "a" key and right with the "d" key
                transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

                //play normal roomba movement sound
            }
        }
                
        /*jumping*/
        //if the player presses the spacebar
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true )
        {
            //add force to playerRb (make the object jump up)
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //debug
            Debug.Log("jump!");

            isOnGround = false;
            
            //play the jump sound
            
        }
    }
    //collision related cases
    private void OnCollisionEnter(Collision collision)
    {
        //if the object collides with anything tagged "ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            //set the player to be back on ground
            isOnGround = true;            
        }
        //if the object collides with anything tagged "enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //stop the player from moving
            hasBeenHitByEnemy = true;
            //play the hit by enemy sound

            //stop the balls from spawning
            bs.enabled = false;
            //pop up a "lose" message

        }
    }
}
