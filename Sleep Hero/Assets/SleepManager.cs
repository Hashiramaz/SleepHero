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
                        StopSleep();

                    }

                }
           //Player Cant Controll Sleep
           }else{








           }

    }
    IEnumerator PlayerTrySleep(){

        sleepRoutineStarted = true;

        yield return new WaitForSeconds(TimeToSleep);
        
        
        StartSleep();






    }


    void StartSleep(){
        isSleeping = true;
        GameManagerGeral.instance.playerSleeping = true;
    }

    void StopSleep(){ 


        isSleeping = false;
        GameManagerGeral.instance.playerSleeping = false;
    }





}
