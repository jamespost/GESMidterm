using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    //fields
    //get access to all relevant in game scripts (player movement, enemy movement, ballspawner)
    //player movement
    PlayerMovement playerMovement;
    //enemy movement
    EnemyMovement enemyMovement;
    //ballspawner
    BallSpawner ballSpawner;
    bool hasPaused = false;
    bool foundEnemy = false;
    //pause game screen
    [SerializeField] GameObject pauseScreen;
        
    private void FixedUpdate()
    {
        //if the player hasn't already paused
        if (!hasPaused)
        {
            //if the player presses the escape key
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //pause the game
                Pause();                
            }
        }
        if (hasPaused)
        {
            //if the player presses the escape key
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //unpause the game
                UnPause();                
            }
        }

    }

    private void Pause()
    {
        
        //player movement
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        //enemy movement
        try
        {
            enemyMovement = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>();
            foundEnemy = true;
        }
        catch
        {
            Debug.Log("Unable to find enemyroomba");
            foundEnemy = false;
        }
        //ballspawner
        ballSpawner = GameObject.Find("Floor").GetComponent<BallSpawner>();

        //disable those components
        playerMovement.canMove = false;
        if (foundEnemy)
        {
            enemyMovement.canMove = false;
        }

        ballSpawner.canSpawnBalls = false;

        //show the pause screen
        pauseScreen.SetActive(true);

        hasPaused = true;
    }

    private void UnPause()
    {
        //enable components
        playerMovement.canMove = true;
        //enemyMovement.enabled = true;
        ballSpawner.canSpawnBalls = true;
        if (foundEnemy)
        {
            enemyMovement.canMove = true;
        }
        //hide the pause screen
        pauseScreen.SetActive(false);

        hasPaused = false;
    }
}
