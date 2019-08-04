using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    public Image sleepFill;

    public GameObject[] HealthHearts;

    public Text Score;
    public GameObject finalScreen;

    public GameObject warningLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshUI(){
        
        sleepFill.fillAmount = GameManagerGeral.instance.actualSleep / GameManagerGeral.instance.maxSleep;
        


    }

    public void RefreshPlayerHealth(int health){
        Debug.Log( "Atualizando vida" + health);
        if(health == 0){
            HealthHearts[0].SetActive(false);
            HealthHearts[1].SetActive(false);
            HealthHearts[2].SetActive(false);
        }
        
        if(health == 1){
            HealthHearts[0].SetActive(true);
            HealthHearts[1].SetActive(false);
            HealthHearts[2].SetActive(false);
        }
        
        if(health == 2){
            HealthHearts[0].SetActive(true);
            HealthHearts[1].SetActive(true);
            HealthHearts[2].SetActive(false);
        }

        if(health == 3){
            HealthHearts[0].SetActive(true);
            HealthHearts[1].SetActive(true);
            HealthHearts[2].SetActive(true);
        }
        
        
        
      

    }

    public void ActivateFinalScreen(){
        finalScreen.SetActive(true);

    }

    public void DesactivateFinalScreen(){
        finalScreen.SetActive(false);
    }


    public void ActivateLevelWarning(){
        warningLevel.SetActive(true);

    }

    public void DesactivateLevelWarning(){
        warningLevel.SetActive(false);
    }




  }
