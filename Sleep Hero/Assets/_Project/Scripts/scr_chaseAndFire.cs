using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_chaseAndFire : MonoBehaviour
{
 
 public float speed;

 public bool movingRight = true;
private bool isVisible;
 public Transform groundDetection;
 public float distanceDetection = 2f;

 private void Fireballthrow()
 {

 }
 public void UpdateVisibile(){
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
 private void Update() {
     //esta na tela
        UpdateVisibile();
     if (isVisible)
     {
            //esta a esquerda do player
            if (NewPlayer.GetAxis.x > Brute.GetAxis.x)
            {   //se movendo na direction do player
                if(movingRight)
                {   //fireball
                    Fireballthrow();
                    //checa se esta na borda ou n
                    RaycastHit2D goundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distanceDetection);
                    if(groundInfo.collider == true)
                    {
                        //se n estiver continue para a borda
                         transform.Translate(Vector2.right * speed * Time.deltaTime);
                    }
                }
                //n esta na direction do player, virar
                else
                {
                    transform.eulerAngles = new Vector3(0,-180,0);
                    movingRight = false;  
                }
            }
            //esta a direita do player
            if(NewPlayer.GetAxis.x < Brute.GetAxis.x)
            {   //esta se movendo pra esquerda
                if(!movingRight)
                {   //fireball
                    Fireballthrow();
                    //checa se esta na borda ou n
                    RaycastHit2D goundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distanceDetection);
                    if(groundInfo.collider == true)
                    {
                        //se n estiver continue para a borda
                         transform.Translate(Vector2.right * speed * Time.deltaTime);
                    }
                }
                //n esta na direction do player, virar
                else
                {
                    transform.eulerAngles = new Vector3(0f,0f,0f);
                    movingRight = true; 
                }
            }
        }
     else{
         // n esta na tela comportamento padrao de patrulha
     transform.Translate(Vector2.right * speed * Time.deltaTime);

     RaycastHit2D goundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distanceDetection);
     if(goundInfo.collider == false){
        if(movingRight == true){
            transform.eulerAngles = new Vector3(0,-180,0);
            movingRight = false;    
        }
        else{
            transform.eulerAngles = new Vector3(0f,0f,0f);
            movingRight = true;
        }
     }
     }
 }

}
