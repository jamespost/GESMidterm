using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkAndDestroy : MonoBehaviour
{
    //if object collides with "Player" then shrink over time and destroy self
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("I've been hit by the player!");
        }
    }
}
