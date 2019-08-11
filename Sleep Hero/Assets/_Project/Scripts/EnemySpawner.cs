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

    public int enemytype = 1;

    UnityEngine.Camera cam;



    public void SpawnEnemy(){



        GameObject enemy = Instantiate(enemyPrefab, spawnArea.GetRandomPoint(),transform.rotation);
        
        //enemy.GetComponent<AIDestinationSetter>().target = playerreference.transform;
        if(enemytype == 1)
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
         cam = UnityEngine.Camera.main;
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


    private void LateUpdate() {
        UpdateVisibility();
    }

    public void UpdateVisibility(){
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
    if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
    {
        //Debug.Log("APARECEU!");
         // Your object is in the range of the camera, you can apply your behaviour
        isVisible = true;
    }
    else{
        //Debug.Log("SUMIU");
    }
        isVisible = false;
    }
 }
