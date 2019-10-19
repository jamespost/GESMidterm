using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShrinkAndDestroy : MonoBehaviour
{
    [SerializeField] Text collectedText;

    //amount to scale transform by
    Vector3 scaleVector;
    [SerializeField] float scaleFactor = 0.25f;


    private void Start()
    {
        //initialize scaleFactor
        scaleVector = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }
    //if object collides with "Player" then shrink over time and destroy self
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //print a debug message
            Debug.Log("I've been hit by the player!");
            //shrink myself
            gameObject.transform.localScale -= scaleVector;
            //print a debug message
            Debug.Log(gameObject.transform.localScale);
            //shrink the object
            if (gameObject.transform.localScale.Equals(new Vector3(0f, 0f, 0f)))
            {
                Destroy(gameObject);
                Debug.Log("Object destroyed");
            }
            
        }
    }
}
