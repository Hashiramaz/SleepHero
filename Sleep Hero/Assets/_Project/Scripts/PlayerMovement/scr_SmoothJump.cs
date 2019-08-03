using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SmoothJump : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private bool isGrounded;
    public Transform GroundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position,checkRadius,whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter =jumpTime;
            rigidbody.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter>0)
            {
            rigidbody.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
            }else{
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
