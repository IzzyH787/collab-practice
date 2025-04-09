using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private LevelManager levelManager;
    //public GameObject lava;
    /* private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Player"))
         {
             PlayerPrefs.SetInt("DropInLava", 1);
             Debug.Log("Achievement Unlocked- in  lava");
         }

     }*/
    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("DropInLava", 1);
            PlayerPrefs.Save();
            Debug.Log("Achievement Unlocked- in  lava");
            levelManager.hitlava = true;
        }
    }
}
