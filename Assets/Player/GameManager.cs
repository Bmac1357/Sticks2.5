using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] public bool recording = true;

    private bool gamePaused = false;

    private float deltaTime;

    //private ReplaySystem replaySystem;

    // Use this for initialization
    void Start ()
    {
        deltaTime = Time.fixedDeltaTime;

        if (!PlayerPrefsManager.IsLevelUnlocked(SceneManager.GetActiveScene().buildIndex))
        {
            Debug.Log("Level " + SceneManager.GetActiveScene().buildIndex + " locked");

            PlayerPrefsManager.UnlockLevel(SceneManager.GetActiveScene().buildIndex);

            Debug.Log("Level " + SceneManager.GetActiveScene().buildIndex + "unlocked");
        }
        else
        {
            Debug.Log("Level " + SceneManager.GetActiveScene().buildIndex + "unlocked");
        }
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
        
        if (Input.GetKeyDown(KeyCode.P))// && !gamePaused)
        {
            PauseGame();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnpauseGame();
        }

       //Debug.Log("Update");
	}

    //
    void PauseGame()
    {
        gamePaused = true;

        Time.timeScale = 0f;

        Time.fixedDeltaTime = 0f;
    }

    //
    void UnpauseGame()
    {
        gamePaused = false;

        Time.timeScale = 1f;

        Time.fixedDeltaTime = deltaTime;
    }

    void OnApplicationPause(bool pause)
    {
        //if (pause)
        {
            Debug.Log("Player within game paused");
        }
    }
}
