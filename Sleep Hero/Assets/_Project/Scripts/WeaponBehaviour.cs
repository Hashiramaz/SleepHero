using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{   
    public int weaponDamage =1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
     private void OnTriggerEnter2D(Collider2D other) {
         if(other.CompareTag("Enemy")){
            Debug.Log("Atacando inimigo");

            bool fromright;
            fromright = other.gameObject.transform.position.x > transform.position.x;


            other.GetComponent<EnemyManager>().TakeDamage(weaponDamage, fromright);
         }
     }

}
