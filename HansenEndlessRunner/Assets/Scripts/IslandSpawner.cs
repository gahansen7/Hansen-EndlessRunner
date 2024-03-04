using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] islandPrefabs;
    [SerializeField] private Transform islandSpawner;
    [SerializeField] private float spawnTimeMin = 2f;
    [SerializeField] private float spawnTimeMax = 6f;
    [SerializeField] private float islandSpeed = .5f;
    public float islandSpawnTime = 10f;

    private float timeUntilIslandSpawn;

    GameManager gameManager;
    

    void Start()
    {
        GameObject islandToSpawn = islandPrefabs[Random.Range(0, islandPrefabs.Length)];

        GameObject spawnedIsland = Instantiate(islandToSpawn, new Vector3 (0,-3,0), Quaternion.identity);

        Rigidbody2D islandRB = spawnedIsland.GetComponent<Rigidbody2D>();
        islandRB.velocity = Vector2.left * (islandSpeed -3.1f );
    }


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
        timeUntilIslandSpawn += Time.deltaTime;

        if (timeUntilIslandSpawn >= islandSpawnTime)
        {
            Spawn();
            islandSpawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            timeUntilIslandSpawn = 0f;

        }

    }

    private void Spawn()
    {
        GameObject islandToSpawn = islandPrefabs[Random.Range(0, islandPrefabs.Length)];

        GameObject spawnedIsland = Instantiate(islandToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D islandRB = spawnedIsland.GetComponent<Rigidbody2D>();
        islandRB.velocity = Vector2.left * islandSpeed;

    }
}