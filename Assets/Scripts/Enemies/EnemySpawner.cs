using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName; // name of wave
        public int waveQuota; // total number of enemies spawning during wave
        public float spawnInterval; // enemy spawning interval
        public int spawnCount; // amount of enemies already spawned during this wave
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
