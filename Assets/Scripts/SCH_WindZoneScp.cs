using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCH_WindZoneScp : MonoBehaviour
{
    //Direction of wind
    public float windDirectionX = 0;
    public float windDirectionY = 0;
    public float windDirectionZ = 0;
    private Vector3 windDirection;

    public GameObject droneObj; //The drone object
    public float windMagnitude = 3f; //Magnitude of the wind

    public AudioClip windBlowingSound;
    public GameObject audioManagerObj;
    private AudioManager audioManagerScp;

    private Rigidbody droneRB; //Rigidbody of the drone
    private bool insideWindArea = false; //Whether the drone is inside the wind area
    

    // Start is called before the first frame update
    void Start()
    {
        droneRB = droneObj.GetComponent<Rigidbody>();
        windDirection.x = windDirectionX;
        windDirection.y = windDirectionY;
        windDirection.z = windDirectionZ;
        audioManagerScp = audioManagerObj.GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == droneObj)
        {
            Debug.Log("Collision enter.");
            insideWindArea = true;
            audioManagerScp.PlayAudio(windBlowingSound);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == droneObj)
        {
            Debug.Log("Collision exit.");
            insideWindArea = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (insideWindArea)
        {
            droneRB.AddForce(windDirection * windMagnitude);
        }
    }
}
