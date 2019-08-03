using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    EnemySpawner[] spawners;

    public float interval = 4f;
    // Start is called before the first frame update
    void Start()
    {
        spawners = FindObjectsOfType<EnemySpawner>();

        InvokeRepeating("SpawnInRandomSpawner", 0f, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnInRandomSpawner(){

        // EnemySpawner spawner =  spawners[Random.Range(0,spawners.Length)];

        // if(!spawner.isVisible){
        //     spawner.SpawnEnemy();
        // }else
        // {
        //     SpawnInRandomSpawner();
        // }

        spawners[Random.Range(0,spawners.Length)].SpawnEnemy();
        
        //spawners[Random.Range(0,spawners.Length)].SpawnEnemy();

    }
}
