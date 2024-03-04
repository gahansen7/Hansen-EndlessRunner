using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] collectablePrefabs;
    [SerializeField] private Transform collectableSpawner;
    [SerializeField] private float spawnTimeMin = 2f;
    [SerializeField] private float spawnTimeMax = 6f;
    [SerializeField] private float collectableSpeed = 3f;
    public float collectableSpawnTime = 2f;

    private float timeUntilCollectableSpawn;

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
        timeUntilCollectableSpawn += Time.deltaTime;

        if (timeUntilCollectableSpawn >= collectableSpawnTime)
        {
            Spawn();
            collectableSpawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            timeUntilCollectableSpawn = 0f;

        }

    }

    private void Spawn()
    {
        GameObject collectableToSpawn = collectablePrefabs[Random.Range(0, collectablePrefabs.Length)];

        GameObject spawnedCollectable = Instantiate(collectableToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D collectableRB = spawnedCollectable.GetComponent<Rigidbody2D>();
        collectableRB.velocity = Vector2.left * collectableSpeed;

    }
}
