using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCollection : MonoBehaviour
{
    //a variable to store the number of balls collected
    public int ballsCollected;
    //a field to alter UI text
    public Text ballCollectedText;
    //amount of balls collected needed to "win"
    [SerializeField] int ballsNeededToWin = 30;

    private void Start()
    {
        ballsCollected = 0;
    }
    //condition to "win" (end) the game
    private void WinCondition()
    {
        if(ballsCollected >= 40)
        {
            //disable all movement scripts

            //show a "you won" UI message on screen

            //load back to the title menu scene after a couple of seconds


        }
    }


}
