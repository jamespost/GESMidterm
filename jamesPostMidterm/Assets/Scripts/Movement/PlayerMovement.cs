using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    //private variables
    [SerializeField] float speed = 20.0f;
    [SerializeField] float turnSpeed = 45.0f;
    [SerializeField] float jumpForce;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject alertScreen;
    [SerializeField] bool requireCablesUnplugged = false;
    private float horizontalInput;
    private float forwardInput;
    private bool isOnGround = true;
    private bool hasBeenHitByEnemy = false;
    private bool isMoving = true;
    private bool alreadyWon = false;
    private int cableCount = 6;
    Rigidbody playerRb;
    BallSpawner bs;
    BallCollection ballCollection;
    AudioClips audioClips;
    AudioSource audioSource;
    public bool canMove = true;
    public bool hasEmptiedTrash = false;
    private Scene scene;

    


    private void Start()
    {
        //initialze variables
        playerRb = GetComponent<Rigidbody>();
        bs = GameObject.Find("Floor").GetComponent<BallSpawner>();
        ballCollection = GetComponent<BallCollection>();
        audioClips = GetComponent<AudioClips>();
        audioSource = GetComponent<AudioSource>();
        scene = SceneManager.GetActiveScene();
        
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
        if (!hasBeenHitByEnemy && canMove)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                isMoving = true;

                if (isMoving)
                {
                    //play normal roomba movement sound
                    audioSource.loop = true;
                    audioSource.PlayOneShot(audioClips.clips[0]);
                    isMoving = false;
                }
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                //We'll move the vehicle forward with the "w" key, and backward with the "s" key
                transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
                //audioSource.loop = true;

            }
            if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                isMoving = false;
                audioSource.loop = false;
                audioSource.Stop();
                audioSource.PlayOneShot(audioClips.clips[2]);
                
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
            audioSource.PlayOneShot(audioClips.clips[1]);
        }

        //check for player jumping over power cables
        CheckIfPlayerJumpedOver();
        //check for wincondition
        if (!alreadyWon)
        {
            WinCondition();
            alertPopUp();
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
            //stop the enemy from moving
            if(collision.gameObject.name == "Boss(Clone)")
            {
                collision.gameObject.GetComponent<BossMovement>().enabled = false;
            }
            if (collision.gameObject.name == "EnemyRoomba(Clone)")
            {
                collision.gameObject.GetComponent<EnemyMovement>().enabled = false;
            }
            //play the hit by enemy sound
            audioSource.PlayOneShot(audioClips.clips[3]);
            //stop the balls from spawning
            bs.canSpawnBalls = false;
            //pop up a "lose" message
            loseScreen.SetActive(true);            
        }
    }

    //check if player jumped over powercable
    //methods
    void CheckIfPlayerJumpedOver()
    {
        GameObject objectHitByHit;
        //check if the player has jumped above the power cable
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            objectHitByHit = hit.collider.gameObject;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            //if player has jumped over the cable, disable self, tell power strip that it has one less cable attached
            if (objectHitByHit.name.Contains("Power Cable") && hasEmptiedTrash)
            {
                Destroy(objectHitByHit);
                cableCount--;
            }
        }
    }

    //popup the alert UI
    private void alertPopUp()
    {
        //if player has emptied trash and requireCablesUnplugged is true
        if(hasEmptiedTrash && requireCablesUnplugged)
        {
            alertScreen.SetActive(true);
            Invoke("disableAlertScreen", 3);
        }
    }

    private void disableAlertScreen()
    {
        alertScreen.SetActive(false);
    }
    
    private void WinCondition()
    {        
        if(requireCablesUnplugged)
        {
            if (hasEmptiedTrash && cableCount == 0)
            {
                //debug
                Debug.Log("Player wins");
                Debug.Log("there are no power cables left");
                //show a "you won" UI message on screen
                winScreen.SetActive(true);
                //disable all movement scripts
                //stop the player from moving
                hasBeenHitByEnemy = true;
                //stop the enemy from moving

                GameObject.Find("Boss(Clone)").GetComponent<BossMovement>().enabled = false;
                GameObject.Find("EnemyRoomba(Clone)").GetComponent<EnemyMovement>().enabled = false;
                Destroy(GameObject.Find("Powerstrip"));
                //stop the balls from spawning
                bs.canSpawnBalls = false;

                alreadyWon = true;
            }

        }
        else
        {
            if (hasEmptiedTrash)
            {
                //debug
                Debug.Log("Player wins");
                Debug.Log("there are no power cables left");
                //show a "you won" UI message on screen
                winScreen.SetActive(true);
                //disable all movement scripts
                //stop the player from moving
                hasBeenHitByEnemy = true;
                //stop the enemy from moving

                GameObject.Find("Boss(Clone)").GetComponent<BossMovement>().enabled = false;
                GameObject.Find("EnemyRoomba(Clone)").GetComponent<EnemyMovement>().enabled = false;
                Destroy(GameObject.Find("Powerstrip"));
                //stop the balls from spawning
                bs.canSpawnBalls = false;

                alreadyWon = true;
            }
        }        
    }
}