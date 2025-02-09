using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject EnemyToSpawn;
    [SerializeField] float xRange = 25f;
    [SerializeField] float zRange = 25f;
    int maxEnemiesCount = 30;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        for(int i =0; i< maxEnemiesCount; i++)
        {
            float randomSpawnX = Random.Range(xRange,-xRange);
            float randomSpawnZ = Random.Range(zRange,-zRange);
        
            Vector3 randomSpawnPoint = new Vector3(randomSpawnX,0,randomSpawnZ);
            Instantiate(EnemyToSpawn,randomSpawnPoint,Quaternion.identity);
    
        }
    }
}
