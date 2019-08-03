using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Attributes")]
    public float health = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
    
    if(other.gameObject.CompareTag("Enemy")){
        TakeDamage(1);
    }
    
    }
    void TakeDamage(float amount){
        Debug.Log("Player Damage Taken");
        health -= amount;
        if(health <= 0){
            Die();
        }

    }

    void Die(){



    }




}
