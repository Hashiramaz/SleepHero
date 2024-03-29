﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    [Header("Settings")]
    public int health;

    public float sleepReward =1f;
    public float speed;

    [Header("Knockback")]
    public float knockback;
    public float knockBackLength;
    public float knockbackCount;
    public bool knockfromRight;

    public GameObject[] deathSpawnOcjects;

    public Rigidbody2D rb{
        get{
            if(m_rb == null)
                m_rb = GetComponent<Rigidbody2D>();
                return m_rb;
        }
    }

    public Rigidbody2D m_rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateKnockBack();
    }


    void UpdateKnockBack(){

        if(knockbackCount > 0){
            if(knockfromRight){
				rb.velocity = new Vector2 ( knockback, knockback);
			}else
			{
				rb.velocity = new Vector2 ( -knockback, knockback);
			}
			knockbackCount -= Time.deltaTime;
        }

    }

    public void TakeDamage(int damage, bool fromRight){

    StartCoroutine(StartTakeDamage(damage, fromRight));
    }

    IEnumerator StartTakeDamage(int damage, bool _fromRight){
       
        health -= damage;
       
       
       FindObjectOfType<AudioManager>().Play("MonsterHurt");
       knockbackCount = knockBackLength;
        
            if(_fromRight)
                knockfromRight = true;
            else
            {
                knockfromRight = false;
            }

       
       
        yield return new WaitForSeconds (knockBackLength);
        if(health <= 0){
            Die();
        }


    }



    public void Die(){
        GameManagerGeral.instance.AddSleepReward(sleepReward);
        FindObjectOfType<AudioManager>().Play("MonsterPop");
        foreach (var obj in deathSpawnOcjects)
        {
            Instantiate(obj, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        // if(other.gameObject.CompareTag("Weapon")){

            
        //     knockbackCount = knockBackLength;
        
        //     if(other.transform.position.x > transform.position.x)
        //         knockfromRight = true;
        //     else
        //     {
        //         knockfromRight = false;
        //     }


        //     int damage = other.gameObject.GetComponent<WeaponBehaviour>().weaponDamage;
            
        //     TakeDamage(damage);

        // }
    }
}
