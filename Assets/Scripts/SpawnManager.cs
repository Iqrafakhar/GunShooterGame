using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    private float spawnRange = 9.0f;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        // SpawnEnemyWave(/*waveNumber*/);
        SpawnEnemyWave();
    }

    // Update is called once per frame
    void Update()
    {
        // enemyCount = FindObjectsOfType<Enemy>().Length;
        //after the all enemy deleted then it will generate a new enemy
        // if(enemyCount == 0)
        //{
        // waveNumber++;
        //SpawnEnemyWave(/*waveNumber*/);
        //SpawnpowerupWave();
        // }
    }
    //getting random location to spawn the enemies 
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    //to spawn enemies dynamically 
    void SpawnEnemyWave(/*int enemiesToSpawn*/)
    {
        for (int i = 0; i < 3/*enemiesToSpawn*/; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }



}
