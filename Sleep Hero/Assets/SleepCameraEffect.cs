using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SleepCameraEffect : MonoBehaviour
{
   
    public PostProcessProfile wakedup;
    public PostProcessProfile sleeping;
    public PostProcessVolume postcc;
    private void Start() {
        
    }



    public void SetSleep(){
        postcc.profile = sleeping;
    }

    public void SetWakedUp(){
        postcc.profile = wakedup;
    }
}
