using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerLavaRise : MonoBehaviour
{
    private bool triggerLavaEvent;

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
            }

            else
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

    }
}
