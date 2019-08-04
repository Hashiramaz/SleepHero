using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMelee : MonoBehaviour
{
    public float timeBtwAttack;
     public float startTimeBtwAttack;
    public WeaponBehaviour weapon;

    public bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAttack();
    }


    void UpdateAttack(){
        if( timeBtwAttack <= 0){
           if(Input.GetButtonDown("Jump")){

               
               
               ActivateAttackSprite();
           }

           timeBtwAttack = startTimeBtwAttack;
       }else{
           timeBtwAttack -= Time.deltaTime;
       }
    }


     public void ActivateAttackSprite(){
       StartCoroutine(StartWeaponObject());

   }

   IEnumerator StartWeaponObject(){
       weapon.gameObject.SetActive(true);

        isAttacking = true;
        Debug.Log("Attacking!");
       yield return new WaitForSeconds (0.3f);
       weapon.gameObject.SetActive(false);
        Debug.Log("Stop Attack");
       isAttacking =  false;
   }
}
