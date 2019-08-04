using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepManager : MonoBehaviour
{
    public bool playerWantsSleep;

    public bool canControlSleep;

    public bool isSleeping;

    public bool sleepRoutineStarted;

    public float TimeToSleep =2f;

    public Animator anim{
        get{
            if(m_anim == null)
            m_anim = transform.root.GetComponent<Animator>();
            return m_anim;

        }
    }

    public Animator m_anim;



    private void Update() {
         if(Input.GetAxisRaw("Vertical") == -1f){
             playerWantsSleep = true;
         }else
         {
             playerWantsSleep = false;
         }
    
        UpdateSleepRoutine();
    
    }


    void UpdateSleepRoutine(){
           
           //Player Can Controll Sleep // Player 
           if(canControlSleep){

                if(playerWantsSleep){
                    
                    if(sleepRoutineStarted == false )
                        StartCoroutine(PlayerTrySleep());


                }else{
                    

                    if(sleepRoutineStarted){
                        StopCoroutine(PlayerTrySleep());
                        sleepRoutineStarted = false;
                        anim.SetBool("startedSleeping", false);
                        StopSleep();

                    }

                }
           //Player Cant Controll Sleep
           }else{








           }

    }
    IEnumerator PlayerTrySleep(){

        sleepRoutineStarted = true;

        anim.SetBool("startedSleeping", true);
        
        yield return new WaitForSeconds(TimeToSleep);
        
        
        StartSleep();






    }


    void StartSleep(){
        isSleeping = true;
        anim.SetBool("isAsleep", true);
        GameManagerGeral.instance.playerSleeping = true;
        GameManagerGeral.instance.SetSleepEffect();
        }

    void StopSleep(){ 


        isSleeping = false;
        anim.SetBool("isAsleep", false);
        StopCoroutine(PlayerTrySleep());
        GameManagerGeral.instance.playerSleeping = false;
        GameManagerGeral.instance.SetWakedupEffect();
    }


    public void Wakeup(){
        isSleeping = false;

    }


}
