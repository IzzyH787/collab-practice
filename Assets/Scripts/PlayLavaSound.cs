using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLavaSound : MonoBehaviour
{
    public GameObject audioManagerObj;
    private AudioManager audioManagerScp;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Play lava sound");
        audioManagerScp = audioManagerObj.GetComponent<AudioManager>();
        audioManagerScp.PlaySoundEffectBGM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
