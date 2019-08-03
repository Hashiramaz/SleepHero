using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Attributes")]
    public float health = 5f;

    [Header("References")]
    public GameObject graphics;

    public Rigidbody2D rb{
        get{
            if(m_rb == null)
                m_rb = GetComponent<Rigidbody2D>();
                return m_rb;
        }
    }

    public Rigidbody2D m_rb;

    [Header("Debug Values")]
    public float horizontalVelocity;
    public float verticalVelocity;



    public float knockback;
    public float knockBackLength;
    public float knockbackCount;
    public bool knockfromRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RefreshVelocity();
    }

    private void OnCollisionEnter2D(Collision2D other) {
    



    if(other.gameObject.CompareTag("Enemy")){
        TakeDamage(1);

        knockbackCount = knockBackLength;
        if(other.transform.position.x > transform.position.x)
            knockfromRight = true;
            else
            {
                knockfromRight = false;
            }


    }
    
    }
    void TakeDamage(float amount){
        //Debug.Log("Player Damage Taken");
        
        
        
        health -= amount;
        if(health <= 0){
            Die();
        }

    }

    void Die(){



    }

    public void FlipPlayer(bool lookRight){
        
            graphics.GetComponent<SpriteRenderer>().flipX = !lookRight;
    }

    public void RefreshVelocity(){
        horizontalVelocity = rb.velocity.x;
        verticalVelocity = rb.velocity.y;
    }







}
