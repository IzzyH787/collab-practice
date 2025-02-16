using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    public int hoopNumber;
    private DroneMovement drone; 
    // Start is called before the first frame update
    void Start()
    {
        drone = GameObject.FindGameObjectWithTag("Player").GetComponent<DroneMovement>();
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
            drone.targetHoop++;
            Debug.Log("Hoop Reached");
        }
    }
}
