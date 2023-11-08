using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float spawnTimer = 1f;
    float elapsedTime = 0;
    GameObject[] spawnPoints;
    [SerializeField] GameObject[] zombies;
    [Range(0f, 3f)][SerializeField] float minTimer, maxTimer;

    // Start is called before the first frame update
    void Start()
    {
        SetTimer();
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnTimer)
        {
            SpawnZombie();
            SetTimer();
        }
    }


    private void SpawnZombie()
    {
        GameObject zombieToSpawn = zombies[UnityEngine.Random.Range(0, zombies.Length)];
        GameObject pointToSpawn = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
        Instantiate(zombieToSpawn, pointToSpawn.transform.position, pointToSpawn.transform.rotation);
    }

    private void SetTimer()
    {
        spawnTimer = UnityEngine.Random.Range(minTimer, maxTimer);
        elapsedTime = 0;
    }
}
