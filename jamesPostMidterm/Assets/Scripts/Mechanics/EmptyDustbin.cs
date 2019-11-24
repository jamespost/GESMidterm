using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyDustbin : MonoBehaviour
{
    //fields
    //has a balltracker
    BallCollection ballCollection;
    public Image dustBinFillbar;

    private void Start()
    {
        //initialize ballCollection
        ballCollection = gameObject.GetComponentInParent<BallCollection>();
        dustBinFillbar = GameObject.Find("Fillbar").GetComponent<Image>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //check to see if the gameobject has collided with anything tagged "Trashbin"
        if(collision.gameObject.tag == "Trashbin")
        {
            //run the empty method
            Empty();
            //debug
            Debug.Log("hit the trashbin");
        }
        
    }

    //"empty" the parent objects ballCollection
    private void Empty()
    {        
        //subtract however many balls the player has from their ballsCollected
        ballCollection.ballsCollected -= ballCollection.ballsCollected;
        //update the players balls collected text
        ballCollection.ballCollectedText.text = "Dustballs Collected: " + ballCollection.ballsCollected;
        //update the fillbar
        dustBinFillbar.fillAmount = 0;
    }
    
}
