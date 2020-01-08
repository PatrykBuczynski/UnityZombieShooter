using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager: MonoBehaviour
{
    //Some reference to PlayerHealth
    public GameObject enemy;
    public float startingSpawnTime = 3f;
    public float delay = 5f;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startingSpawnTime, delay);
    }

    // Update is called once per frame
    void Spawn()
    {
        //Have to check if Player have still health, if not then return;

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }


}
