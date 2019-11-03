using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    //prefab object to instantiate
    [SerializeField] GameObject objectToSpawn;
    //how often balls should spawn
    [SerializeField] float objectSpawnRate = 1f;
    //maximum number of objects to instantiate
    //[SerializeField] int maxSpawnNumber = 30;
    private int objectsSpawned = 0;


    private void Start()
    {
        InvokeRepeating("SpawnObjectsAtRandomLocation", objectSpawnRate, objectSpawnRate);
    }
    //a method to instantiate objectToSpawn at a random position in the level space
    private void SpawnObjectsAtRandomLocation()
    {
        int randX = Random.Range(-19, 19);
        int randZ = Random.Range(-19, 3);
        //instantiate the objectToSpawn at a random location within the bounds of the level
        Instantiate(objectToSpawn, new Vector3(randX, 0.5f, randZ), Quaternion.identity);
        //set the objectToSpawns ballCollection component to the player's ball collection compononent
        objectToSpawn.GetComponent<BallCollision>().ballCollection = GameObject.FindGameObjectWithTag("Player").GetComponent<BallCollection>();
    }

}
