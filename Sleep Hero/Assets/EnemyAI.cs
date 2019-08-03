using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nexWaypointDistance = 3f;
    public Transform enemyGFX;

    Path path; 
    int currentWaypoint =0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    private void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        

    }

    void OnPathComplete(Path p){
        if(!p.error){
            path =p;
            currentWaypoint = 0;
        }
    }

void UpdatePath(){
    if(seeker.IsDone())
    seeker.StartPath(rb.position, target.position,OnPathComplete);
}


private void Update() {
    if(path == null)
        return;

        if(currentWaypoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        }else{
            reachedEndOfPath = false;
        }



        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nexWaypointDistance){
            currentWaypoint++;
        }

        if(force.x >= 0.01f ){
            enemyGFX.localScale = new Vector3(enemyGFX.localScale.x,enemyGFX.localScale.y,enemyGFX.localEulerAngles.z);
        }
        else if(force.x <= -0.01f)
        {
            enemyGFX.localEulerAngles = new Vector3 (-enemyGFX.localScale.x,enemyGFX.localRotation.y,enemyGFX.localScale.z);
        }

}
    
}
