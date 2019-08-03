using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int health;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage){
        health -= damage;

        if(health <= 0){
            Die();
        }
        Debug.Log("Damage Taken");

    }

    public void Die(){
        Destroy(gameObject);
    }
}
