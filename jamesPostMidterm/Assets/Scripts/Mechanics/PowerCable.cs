using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCable : MonoBehaviour
{
    //fields
    bool playerHasJumpedOver = false;
    public string objectHitByHit;

    private void Update()
    {
        CheckIfPlayerJumpedOver();
    }

    


}
