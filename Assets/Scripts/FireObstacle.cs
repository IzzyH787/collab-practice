using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireObstacle : MonoBehaviour
{
    public ParticleSystem particle;
    public DroneMovement drone;

    private float delay = 1.5f;
    private bool movementSlow = false;

    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //when player clicks button hides restart button.
        if (movementSlow == true)
        {
            //countdown
            if (delay > 0)
            {
                delay -= Time.deltaTime;
                drone.speed = 0.2f;
                drone.riseSpeed = 5f;
            }

            //when below 0 load scene "game"
            if (delay < 0)
            {
                drone.speed = 0.5f;
                drone.riseSpeed = 8f;
                movementSlow = false;
                delay = 1.5f;
            }
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {

            movementSlow = true;

            Debug.Log(drone.speed);
        }
            
    }
}
