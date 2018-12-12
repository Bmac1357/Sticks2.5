using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    [SerializeField] public bool recording = true;

    //private ReplaySystem replaySystem;

    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        //if (CrossPlatformInputManager.GetButton("Fire1") && !recording)
        if ( CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
            //replaySystem.PlayBack();
        }
        else
        {
            recording = true;
            //replaySystem.Record();          
        }
        
	}

    /*
    public void SetRecord(bool isRecording)
    {
        recording = isRecording;
    }
    */
}
