using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemySpawner : MonoBehaviour
{

    public SpawnArea spawnArea;
    public GameObject enemyPrefab;
    public GameObject playerreference;
    public float spawnInterval = 4f;
    
    public bool isSpawning;

    public bool isVisible;
    public void SpawnEnemy(){



        GameObject enemy = Instantiate(enemyPrefab, spawnArea.GetRandomPoint(),transform.rotation);
        
        //enemy.GetComponent<AIDestinationSetter>().target = playerreference.transform;
        enemy.GetComponent<EnemyAI>().target = playerreference.transform;
    }


    IEnumerator SpawnEnemyRoutine(float _interval){
        
        while(isSpawning){
            SpawnEnemy();
        yield return new WaitForSeconds (_interval);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //StartSpawn();
    }


    public void StartSpawn(){
        isSpawning = true;
        StartCoroutine(SpawnEnemyRoutine(spawnInterval));
    }

    public void StopSpawn(){
        StopCoroutine("SpawnEnemyRoutine");
        isSpawning = false;
    }


    void OnBecameInvisible()
    {
        isVisible = false;
        Debug.Log("IsInvisible");
    }

    void OnBecameVisible()
    {
        isVisible = true;
    }
}
