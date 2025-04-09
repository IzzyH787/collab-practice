using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerLavaRise : MonoBehaviour
{
    private bool triggerLavaEvent;
    private float warningDisplayTime;
    private bool warned;

    [SerializeField] private GameObject lava;
    [SerializeField] private GameObject warning;

    // Start is called before the first frame update
    void Start()
    {
        triggerLavaEvent = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerLavaEvent == true)
        {
            if (lava.transform.position.y <= 30.5f)
            {
                lava.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
                lava.transform.eulerAngles += new Vector3(0, 2, 0) * Time.deltaTime;
                warning.SetActive(true);
                if (!warned)
                {
                    warningDisplayTime = Time.time;
                    warned = true;
                }
                
            }
            //die warning after 3s
            if (Time.time - warningDisplayTime > 3.0f)
            {
                warning.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if colliding with player and is the target hoop 
        if (other.gameObject.CompareTag("Player"))
        {
            triggerLavaEvent = true;

        }

        if (lava.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Drop in lava", 1);
            Debug.Log("Achievement Unlocked");
        }

    }
}
