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

    private void Start()
    {
        ballsCollected = 0;
    }


}
