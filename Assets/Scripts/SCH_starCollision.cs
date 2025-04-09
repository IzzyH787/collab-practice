using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCH_starCollision : MonoBehaviour
{
    public GameObject droneObj; //The drone object
    private Rigidbody droneRB; //Rigidbody of the drone

    // Start is called before the first frame update
    void Start()
    {
        droneRB = droneObj.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == droneObj)
        {
            PlayerPrefs.SetInt("IsStarReached", 1);
            PlayerPrefs.Save();
            Debug.Log("You became the star!");
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
