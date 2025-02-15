using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] GameObject keysToSpawn;
    [SerializeField] GameObject safeArea;

    [SerializeField] float xRange = 60f;
    [SerializeField] float zRange = 60f;
    [SerializeField] float yHeight = 0.25f;
    int maxEnemiesCount = 60;
    int maxKeyCount =3;
    int maxSafeZone = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects(maxEnemiesCount,enemyToSpawn,0f);
        SpawnObjects(maxKeyCount,keysToSpawn,yHeight);
        SpawnObjects(maxSafeZone,safeArea,0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects(int count, GameObject objectToSpawn, float height)
    {
        for(int i =0; i< count; i++)
        {
            float randomSpawnX = Random.Range(xRange,-xRange);
            float randomSpawnZ = Random.Range(zRange,-zRange);
        
            Vector3 randomSpawnPoint = new Vector3(randomSpawnX,height,randomSpawnZ);
            Instantiate(objectToSpawn,randomSpawnPoint,Quaternion.identity);
    
        }
    }

}
