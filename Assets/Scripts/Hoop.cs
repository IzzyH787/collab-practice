using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    public int hoopNumber;
    private DroneMovement drone;

    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        drone = GameObject.FindGameObjectWithTag("Player").GetComponent<DroneMovement>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hoopNumber == drone.targetHoop)
        {
            //highlight hoop
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if colliding with player and is the target hoop 
        if (other.gameObject.CompareTag("Player") && hoopNumber == drone.targetHoop)
        {
            //check if final hoop in track
            if (hoopNumber == levelManager.lastHoopNumber)
            {
                Debug.Log("Level WIn");
            }
            else
            {
                drone.targetHoop++;
                Debug.Log("Hoop Reached");
            }
           
        }
        
    }
}
