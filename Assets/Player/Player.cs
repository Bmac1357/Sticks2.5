using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        float hz = CrossPlatformInputManager.GetAxis("Horizontal");

        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        //Debug.Log("h=" + hz + " v=" + vert);
        //Debug.Log("h=" + hz);

    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Debug.Log("Player within game paused");
        }
    }
}
