using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
 
 public float speed;

 public bool movingRight = true;

 public Transform groundDetection;
 public float distanceDetection = 2f;

 private void Update() {
     transform.Translate(Vector2.right * speed * Time.deltaTime);

     RaycastHit2D goundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distanceDetection);
     if(goundInfo.collider == false){
        if(movingRight == true){
            transform.eulerAngles = new Vector3(0,-180,0);
            movingRight = false;    
        }else{
            transform.eulerAngles = new Vector3(0f,0f,0f);
            movingRight = true;
        }
     }
 }

}
