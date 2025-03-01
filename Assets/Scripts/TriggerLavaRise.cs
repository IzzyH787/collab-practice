using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLavaRise : MonoBehaviour
{
    bool triggerLavaEvent;

    [SerializeField] private GameObject lava;

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
            lava.transform.position += new Vector3(0, 2, 0) * Time.deltaTime;
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
