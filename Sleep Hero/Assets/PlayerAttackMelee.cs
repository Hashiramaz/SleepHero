using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMelee : MonoBehaviour
{
    public float timeBtwAttack;
     public float startTimeBtwAttack;
     public float attackduration= 0.1f;
    public WeaponBehaviour weapon;

    public ParticleSystem attackFX;    
    public Animator anim{
        get{
            if(m_anim == null)
            m_anim = transform.root.GetComponent<Animator>();
            return m_anim;

        }
    }

    public Animator m_anim;

        public Player player{
        get{
            if(m_player == null)
                m_player = GetComponent<Player>();
                return m_player;
        }
    }
    public Player m_player;
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

        attackFX.Play();
        //Set Animation
         //anim.SetBool("IsAttacking", true);
         anim.SetTrigger("Attack");

        //Set Camer Animation
        player.cam.GetComponent<Animator>().SetTrigger("Shake");        
        
        Debug.Log("Attacking!");
       yield return new WaitForSeconds (attackduration);
       weapon.gameObject.SetActive(false);
        Debug.Log("Stop Attack");
       isAttacking =  false;

       //set animatiojn
       anim.SetBool("IsAttacking", false);

   }
}
