using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public Enemy enemy;

    Wave currentWave;
    int currentWaveNumber;

    int enemiesRemainingToSpawn;
    int enemiesRemainingAlive;
    float nextSpawnTime;
    float nextWaveTime;
    bool waveOver = false;

    void Start() 
    {
        NextWave ();
    }

    void Update()
    {
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate (enemy, Vector3.zero, Quaternion.identity) as Enemy;
            spawnedEnemy.OnDeath += OnEnemyDeath;
        }

        WaveTimer();
    }

    void WaveTimer()
    {
        if (waveOver && Time.time > nextWaveTime) 
        {
            waveOver = false;
            NextWave();
        }
    }

    void OnEnemyDeath() 
    {
        enemiesRemainingAlive--;
        if (enemiesRemainingAlive == 0 && !waveOver)
        {
            waveOver = true;
            print("end of wave");
            nextWaveTime = Time.time + currentWave.timeToNextWaves;

        }
    }

    void NextWave()
    {
        currentWaveNumber++ ;
        print("Wave " + currentWaveNumber);
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];
            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = currentWave.enemyCount;
        }
        else
        {
            print("No more waves!");
        }
    }

    [System.Serializable]
    public class Wave {
        public int enemyCount = 1;
        public float timeBetweenSpawns = 1;
        public float timeToNextWaves = 1;

    }
}
