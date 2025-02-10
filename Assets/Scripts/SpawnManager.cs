using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] GameObject keysToSpawn;
    [SerializeField] GameObject safeArea;

    [SerializeField] float xRange = 25f;
    [SerializeField] float zRange = 25f;
    int maxEnemiesCount = 30;
    int maxKeyCount =3;
    int maxSafeZone = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects(maxEnemiesCount,enemyToSpawn);
        SpawnObjects(maxKeyCount,keysToSpawn);
        SpawnObjects(maxSafeZone,safeArea);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects(int count, GameObject objectToSpawn)
    {
        for(int i =0; i< count; i++)
        {
            float randomSpawnX = Random.Range(xRange,-xRange);
            float randomSpawnZ = Random.Range(zRange,-zRange);
        
            Vector3 randomSpawnPoint = new Vector3(randomSpawnX,0,randomSpawnZ);
            Instantiate(objectToSpawn,randomSpawnPoint,Quaternion.identity);
    
        }
    }

}
