using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireObstacle : MonoBehaviour
{
    public ParticleSystem particle;
    public DroneMovement drone;
    [SerializeField] private GameObject slowed;

    private float delay = 1.5f;
    private bool movementSlow = false;

    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //when player collides with particle
        if (movementSlow == true)
        {
            //countdown start (decrease speed)
            if (delay > 0)
            {
                delay -= Time.deltaTime;
                drone.speed = 0.5f;
                drone.riseSpeed = 5f;
                slowed.SetActive(true);
            }

            //countdown finish (reset speed)
            if (delay < 0)
            {
                drone.speed = 10f;
                drone.riseSpeed = 8f;
                movementSlow = false;
                slowed.SetActive(false);
                delay = 1.5f;
            }

            Debug.Log(drone.speed);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            movementSlow = true;
        }
        
        else if (other.tag == null)
        {
            PlayerPrefs.SetInt("Didn't touch lava", 1);
            Debug.Log("Achievement Unlocked");
        }
        
    }

    private void OnParticleTrigger()
    {
        Debug.Log("particle");
    }
}
