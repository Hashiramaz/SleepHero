using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{


    public float horizontal;
    public float vertical;

    public float speed = 5f;

    public Animator PlayerAnimationController; //Wolter - Added animator

    public Rigidbody2D rb;


    Vector2 vectorHorizontalmovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        UpdatePlayerMovement();

        


    }




    public void UpdateInputs(){


    }

    public void UpdatePlayerMovement(){

        Vector2 movHorizontal;
        movHorizontal = transform.right * horizontal;

        vectorHorizontalmovement = movHorizontal * speed;

        if(vectorHorizontalmovement != Vector2.zero){
            
            Vector2 pos  = new Vector2(transform.position.x, transform.position.y) + vectorHorizontalmovement * Time.fixedDeltaTime;
            rb.MovePosition(pos);
        }

        PlayerAnimationController.SetFloat("speed",Mathf.Abs(horizontal));
    }

    
}
