using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

    GameObject player;
    //Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");

       //offset = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Transform.lookAt

        //transform.LookAt(player.transform.position);

        //Vector3 rot = transform.rotation;

        //pos.x += Input.GetAxis("RHoriz");

        //transform.position = pos;

        //Debug.Log("RHoriz" + Input.GetAxis("RHoriz"));
        //Debug.Log("RVert"  + Input.GetAxis("RVert"));
    }

    void LateUpdate()
    {
        transform.LookAt(player.transform.position);
    }
}
