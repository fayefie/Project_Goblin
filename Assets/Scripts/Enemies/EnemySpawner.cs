using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName; // name of wave
        public List<EnemyGroup> enemyGroups; // list of enemy groups to spawn
        public int waveQuota; // total number of enemies spawning during wave
        public float spawnInterval; // enemy spawning interval
        public int spawnCount; // amount of enemies already spawned during this wave
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName; // the name of enemies that are spawning this wave
        public int enemyCount; // the number of enemies that are spawning this wave
        public int spawnCount; // amount of enemies already spawned during this wave
        public GameObject enemyPrefab; // enemy types spawning for this wave
    }

    public List<Wave> waves; // list of all waves in game
    public int currentWaveCount; // index of current wave

    [Header("Spawn Attributes")]
    float spawnTimer; // timer that determines when the next enemy spawns
    public float waveInterval; // the interval between waves
    public int enemiesAlive; // amount of enemies currently existing
    public int maxEnemiesAllowed; // how many enemies are allowed to exist at once
    public bool maxEnemiesReached; // flag for checking if max amount of enemies was reached

    [Header("Spawn Positions")]
    public List<Transform> relativeSpawnPoints; // stores all the relative spawn points of enemeis
    
    Transform player;
    Transform enemyParentEmpty;

    private void Awake()
    {
        enemyParentEmpty = GameObject.Find("Enemies").transform;
    }

    void Start()
    {
        player = FindFirstObjectByType<PlayerStats>().transform;
        CalculateWaveQuota();
    }

    void Update()
    {
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0) // check if prev wave ended and new one should spawn
        {
            StartCoroutine(BeginNextWave());
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);

        if (currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }

    void SpawnEnemies()
    {
        // checks if min number of enemies have spawned
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota)
        {
            // spawns enemies per type until quota is filled
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                // checks if the min number of enemies of specific type have spawned
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    // limits number of enemies that can spawn at once
                    if (enemiesAlive >= maxEnemiesAllowed)
                    {
                        maxEnemiesReached = true;
                        return;
                    }

                    // spawn enemies at random positions close to player
                    GameObject SpawnedEnemies = Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);
                    SpawnedEnemies.transform.SetParent(enemyParentEmpty);

                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;
                }
            }
        }

        // reset maxEnemiesReached if the number of enemies drops below the allowed max amount
        if (enemiesAlive < maxEnemiesAllowed)
        {
            maxEnemiesReached = false;
        }
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;
    }
}
