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

    bool isWaveTransitioning = false;

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
        if (currentWaveCount >= waves.Count)
            return;

        Wave currentWave = waves[currentWaveCount];

        // Spawn enemies at the configured interval.
        if (currentWave.spawnCount < currentWave.waveQuota)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= currentWave.spawnInterval)
            {
                spawnTimer = 0f;
                SpawnEnemies();
            }
        }

        // Transition only after spawning is complete and all enemies are dead.
        if (currentWave.spawnCount >= currentWave.waveQuota &&
            enemiesAlive == 0 &&
            !isWaveTransitioning)
        {
            StartCoroutine(BeginNextWave());
        }
    }

    IEnumerator BeginNextWave()
    {
        isWaveTransitioning = true;

        Debug.Log($"Wave {currentWaveCount + 1} cleared. Waiting {waveInterval} seconds.");

        yield return new WaitForSeconds(waveInterval);

        if (currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;

            // Reset the spawn timer.
            spawnTimer = 0f;

            // Reset counters for the new wave.
            waves[currentWaveCount].spawnCount = 0;

            foreach (EnemyGroup group in waves[currentWaveCount].enemyGroups)
            {
                group.spawnCount = 0;
            }

            CalculateWaveQuota();

            Debug.Log($"Starting wave {currentWaveCount + 1}");
        }
        else
        {
            Debug.Log("All waves completed!");
        }

        isWaveTransitioning = false;
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuota;
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
        enemiesAlive = Mathf.Max(0, enemiesAlive - 1);
    }
}
