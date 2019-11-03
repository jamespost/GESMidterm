using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCollision : MonoBehaviour
{
    //amount to scale transform by
    Vector3 scaleVector;
    [SerializeField] float scaleFactor = 0.25f;
    public GameObject player ;
    public BallCollection ballCollection;
    bool isDestroyed = false;
    bool hitByEnemy = false;
    bool hitByPlayer = false;

    //audio fields
    RandomizedOneshot randomizedOneshot;
    AudioClips audioClips;
    AudioSource audioSource;
    //initialize fields
    private void Awake()
    {
        
    }

    private void Start()
    {
        //initialize
        randomizedOneshot = GetComponent<RandomizedOneshot>();
        audioSource = GetComponent<AudioSource>();
        audioClips = GetComponent<AudioClips>();

        
        scaleVector = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        //get the player's ball collection script
        player = GameObject.FindWithTag("Player");
        ballCollection = player.GetComponent<BallCollection>();

        //play the dustball spawn sound
        randomizedOneshot.PlayRandomizedAudioClip();

    }

    private void Update()
    {
        //if the gameobject is scaled to a factor of 0
        if (gameObject.transform.localScale.Equals(new Vector3(0f, 0f, 0f)))
        {            
            Destroy(gameObject);
            isDestroyed = true;
        }

        //if the gameobject is destroyed and hitByPlayer
        if (isDestroyed && hitByPlayer == true)
        {
            Debug.Log("Object destroyed");
            //increment the player's ballsCollected
            ballCollection.ballsCollected++;
            ballCollection.ballCollectedText.text = "Dustballs Collected: " + ballCollection.ballsCollected;
            AudioSource targetSource = player.GetComponent<AudioSource>();
            targetSource.PlayOneShot(player.GetComponent<AudioClips>().clips[4]);
        }
    }
    //if object collides with "Player" then shrink over time and destroy self
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            hitByPlayer = true;
            hitByEnemy = false;
            //print a debug message
            //Debug.Log("I've been hit by the player!");
            //shrink myself
            if (gameObject.transform.localScale.x > 0f && gameObject.transform.localScale.y > 0f && gameObject.transform.localScale.z > 0f)
            {
                //shrink the object
                gameObject.transform.localScale -= scaleVector;
                //print a debug message
                Debug.Log(gameObject.transform.localScale);
            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            hitByEnemy = true;
            hitByPlayer = false;
            //print a debug message
            //Debug.Log("I've been hit by the player!");
            //shrink myself
            if (gameObject.transform.localScale.x > 0f && gameObject.transform.localScale.y > 0f && gameObject.transform.localScale.z > 0f)
            {
                //shrink the object
                gameObject.transform.localScale -= scaleVector;
                //print a debug message
                //Debug.Log(gameObject.transform.localScale);
            }
        }
    }
}
