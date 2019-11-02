using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    private BallCollection player;
    private bool roombaSpawned = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BallCollection>();
    }

    private void Update()
    {
        if (player.ballsCollected == 20)
        {
            SpawnEnemyAtRandomLocation();
        }
    }

    private void SpawnEnemyAtRandomLocation()
    {
        if (roombaSpawned == false)
        {
            int randX = Random.Range(-19, 19);
            int randZ = Random.Range(-19, 19);
            //instantiate the enemy roomba at a random location within the level
            Instantiate(Boss, new Vector3(randX, 0.5f, randZ), Quaternion.identity);
            roombaSpawned = true;
        }


    }

}
