using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ChaseAndFire : MonoBehaviour
{
    public float speed;
    public bool isVisible;
UnityEngine.Camera cam;
 public bool movingRight = true;
 public Transform target;
 public Transform groundDetection;
 public float distanceDetection = 2f;


 private void Update() {
    //check for visibility
    UpdateVisibility();
    if(isVisible)
    {
        if(transform.position.x < target.position.x)
        {
            if(movingRight)
            {
                Fireball();
                 RaycastHit2D goundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distanceDetection);
                 if(goundInfo.collider == true)
                 {
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                 }
            }
            else
            {
            transform.eulerAngles = new Vector3(0f,0f,0f);
            movingRight = true;
            }
        }
        if(transform.position.x > target.position.x)
        {
            if(!movingRight)
            {
                Fireball();
                 RaycastHit2D goundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distanceDetection);
                 if(goundInfo.collider == true)
                 {
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                 }
            }
            else
            {
            transform.eulerAngles = new Vector3(0,-180,0);
            movingRight = false;
            }
        }
    }
    else
    {
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

    public void Fireball()
    {
        //yes
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
