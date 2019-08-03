using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   
   public float timeBtwAttack;
   public float startTimeBtwAttack;

   public Transform attackpos;
   public LayerMask whatIsEnemy;
   public float attackRange;

   public int damage;

   public GameObject attackSprite;

   private void Update() {
       if( timeBtwAttack <= 0){
           if(Input.GetKeyDown(KeyCode.Mouse0)){

               Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackpos.position, attackRange,whatIsEnemy );

               for (int i = 0; i < enemiesToDamage.Length; i++)
               {
                   enemiesToDamage[i].GetComponent<EnemyManager>().TakeDamage(damage);
               }
                
               Debug.Log("Attacking");
               ActivateAttackSprite();
           }

           timeBtwAttack = startTimeBtwAttack;
       }else{
           timeBtwAttack -= Time.deltaTime;
       }
   }



   private void OnDrawGizmosSelected() {
       
   
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(attackpos.position,attackRange);
   }


   public void ActivateAttackSprite(){
       StartCoroutine(StartAttackSprite());

   }

   IEnumerator StartAttackSprite(){
       attackSprite.SetActive(true);
       yield return new WaitForSeconds (0.3f);
       attackSprite.SetActive(false);
   }
}
