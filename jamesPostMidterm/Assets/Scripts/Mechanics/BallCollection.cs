using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCollection : MonoBehaviour
{
    //a variable to store the number of balls collected
    public float ballsCollected;
    //a field to alter UI text
    public Text ballCollectedText;
    //amount of balls collected needed to "win"
    public float ballsNeededToWin = 5;


    private void Start()
    {
        ballsCollected = 0;
    }
}
