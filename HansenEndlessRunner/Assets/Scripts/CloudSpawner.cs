using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] cloudPrefabs;
    [SerializeField] private Transform cloudSpawner;
    [SerializeField] private float spawnTimeMin = 2f;
    [SerializeField] private float spawnTimeMax = 6f;
    [SerializeField] private float cloudSpeed = .5f;
    public float cloudSpawnTime = 10f;

    private float timeUntilCloudSpawn;

    GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        gameManager = GameManager.Instance;
        {
            SpawnLoop();
        }

    }

    private void SpawnLoop()
    {
        timeUntilCloudSpawn += Time.deltaTime;

        if (timeUntilCloudSpawn >= cloudSpawnTime)
        {
            Spawn();
            cloudSpawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            timeUntilCloudSpawn = 0f;

        }

    }

    private void Spawn()
    {
        GameObject cloudToSpawn = cloudPrefabs[Random.Range(0, cloudPrefabs.Length)];

        GameObject spawnedCloud = Instantiate(cloudToSpawn, transform.position, Quaternion.identity);

       Rigidbody2D cloudRB = spawnedCloud.GetComponent<Rigidbody2D>();
       cloudRB.velocity = Vector2.left * cloudSpeed;

    }
}