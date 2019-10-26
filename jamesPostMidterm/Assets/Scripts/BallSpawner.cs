using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    //prefab object to instantiate
    [SerializeField] GameObject objectToSpawn;
    //maximum number of objects to instantiate
    [SerializeField] int maxSpawnNumber;



    //a method to instantiate objectToSpawn at a random position in the level space
    private void SpawnObjectsAtRandomLocation()
    {
        //testing functionality of example code found at: https://answers.unity.com/questions/1590160/how-to-spawn-objects-within-a-planes-dimensions.html


    }

}
