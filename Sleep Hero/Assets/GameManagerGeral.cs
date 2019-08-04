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

    //public int level;
    public float[] Difficulty;


    public float interval;
    


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

    }


public    void StartGame(){

        isPlaying = true;
        StartCoroutine(SleepRoutine());
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
            yield return new WaitForSeconds(interval);


        }
    }


    void SetDifficulty(int level){
       sleepLoseAmount = Difficulty[level];

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
}
