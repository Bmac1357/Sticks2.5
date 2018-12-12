using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    //private MyKeyFrame keyFrame;
    private const int BUFFER_SIZE = 500;

    private int frameCount = 0;

    private MyKeyFrame[] keyFrames = new MyKeyFrame[BUFFER_SIZE];

    private Rigidbody rigidBody;

    private GameManager gameManager;


    // Circular buffer
	// Use this for initialization
	void Start ()
    {
        frameCount = 0;

        rigidBody = GetComponent<Rigidbody>();

        gameManager = FindObjectOfType<GameManager>();
    }
	
    public void AddKeyFrame(float time, Vector3 position, Quaternion rotation)
    {
        MyKeyFrame keyFrame = new MyKeyFrame(time, position, rotation);

        // add to buffer
    }

	// Update is called once per frame
	void Update ()
    {  
        if (gameManager.recording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }

    }

    //
    public void Record()
    {
        rigidBody.isKinematic = false;

        // Get active location in circular buffer
        //int frame = Time.frameCount % BUFFER_SIZE; // loops from 0 -> (SIZE - 1)
        //int frame = frameCount % BUFFER_SIZE; // loops from 0 -> (SIZE - 1)

        // Store current frame
        keyFrames[frameCount] = new MyKeyFrame(Time.time, transform.position, transform.rotation);

        frameCount++;

        if (frameCount >= BUFFER_SIZE)
        {
            frameCount = 0;
        }  
    }

    //
    public void PlayBack()
    {
        rigidBody.isKinematic = true;

        // Get active location in circular buffer
        //int frame = Time.frameCount % BUFFER_SIZE; // loops from 0 -> (SIZE - 1)
        //int frame = Time.frameCount % BUFFER_SIZE; // loops from 0 -> (SIZE - 1)

         //frameCount = Time.frameCount;

        //int frame = frameCount % BUFFER_SIZE; // loops from 0 -> (SIZE - 1)

        MyKeyFrame keyFrame = keyFrames[frameCount];

        if (keyFrame != null)
        {
            transform.position = keyFrame.pos;
            transform.rotation = keyFrame.rot;
        }

        frameCount--;// Time.frameCount;

        if (frameCount < 0)
        {
            frameCount = BUFFER_SIZE - 1;
        }

    }
}

public class MyKeyFrame
{
    public float frameTime;
    public Vector3 pos;
    public Quaternion rot;

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot)
    {
        this.frameTime = time;
        this.pos = pos;
        this.rot = rot;
    }

    public MyKeyFrame GetKeyFrame()
    {
        return this;
    }



}

