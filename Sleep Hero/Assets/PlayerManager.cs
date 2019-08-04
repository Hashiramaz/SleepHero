using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Attributes")]
    public float health = 3f;

    public float maxHealth =3f;

    [Header("References")]
    public GameObject graphics;

    protected Rigidbody2D rb{
        get{
            if(m_rb == null)
                m_rb = GetComponent<Rigidbody2D>();
                return m_rb;
        }
    }

    protected Rigidbody2D m_rb;

    [Header("Debug Values")]
    public float horizontalVelocity;
    public float verticalVelocity;

    public GameObject Gamemanager;

    public float knockback;
    public float knockBackLength;
    public float knockbackCount;
    public bool knockfromRight;

    

    // Start is called before the first frame update
    void Start()
    {
        GameManagerGeral.instance.uIManager.RefreshPlayerHealth((int)health);
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
       
        
        
        
        health -= amount;
        
        

        GameManagerGeral.instance.uIManager.RefreshPlayerHealth((int)health);
        if(health <= 0){
            Die();
        }

    }

    void Die(){

        Debug.Log("MORREU");
        GameManagerGeral.instance.StopGame();

    }

    // public void FlipPlayer(bool lookRight){
        
    //         graphics.GetComponent<SpriteRenderer>().flipX = !lookRight;
    // }

    public void RefreshVelocity(){
        horizontalVelocity = rb.velocity.x;
        verticalVelocity = rb.velocity.y;
    }







}
