using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerGeral : MonoBehaviour
{   
    [Header("References")]
    public UIManager uIManager;

    [Header("Debug Variables")]
    public bool isPlaying;
    public float actualSleep;
    public float maxSleep;
    public float sleepLoseAmount;



    public static GameManagerGeral instance;


    

    
    [Header("Settings")]
    public float startSleep =100f;

    public float sleepAddAmount = -3f;
    //public int level;
    public float[] Difficulty;
    public int maxLevel=5;
    public int actualLevel;


    public float Sleepinterval;
    
    public float levelInterval = 25f;

    public bool playerSleeping;


private void Awake() {
    if(instance == null)
     instance = this;
}

private void Start() {
    ResetGame();
    StartGame();
}


    private void Update() {

        if(Input.GetKeyDown(KeyCode.R))
            ResetGame();

        if(Input.GetKeyDown(KeyCode.T))
            StartGame();

        if(Input.GetKeyDown(KeyCode.Y))
            StopGame();

        RefreshPlayerSleep();

    }


    public void StartGame(){

        isPlaying = true;
        StartCoroutine(SleepRoutine());
        StartLevelRoutine();


        uIManager.DesactivateFinalScreen();
    
    }

    
    
    public void StopGame(){
        isPlaying = false;
        uIManager.ActivateFinalScreen();
    }   

    
    public void ResetGame(){

        actualSleep = startSleep;
        SetDifficulty(1);
        
    }


    IEnumerator SleepRoutine(){

        while (isPlaying)
        {
            actualSleep -= sleepLoseAmount;
            uIManager.RefreshUI();
            yield return new WaitForSeconds(Sleepinterval);


        }
    }


    void SetDifficulty(int level){
       sleepLoseAmount = Difficulty[level-1];
       actualLevel = level;

    }

    public void AddSleepReward(float amount){
        actualSleep +=amount;
    }


    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }

    public void PlayAgain(){
        SceneManager.LoadScene("FinalLevel");
        
    }



    public void StartLevelRoutine(){
        StartCoroutine(LevelIncreaseRoutine());
    }


    IEnumerator LevelIncreaseRoutine(){
      while(isPlaying){

        yield return new WaitForSeconds(levelInterval);
        if(actualLevel < maxLevel){
            actualLevel ++;
           // SetDifficulty (actualLevel);
            
        }

        uIManager.ActivateLevelWarning();
        yield return new WaitForSeconds (2f);
        uIManager.DesactivateLevelWarning();
      }
    
    }

    void RefreshPlayerSleep(){
        if(playerSleeping){
            sleepLoseAmount = sleepAddAmount;
        }else{
            SetDifficulty(actualLevel);
        }
    }



}
