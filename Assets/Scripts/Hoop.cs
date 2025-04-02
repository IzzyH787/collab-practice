using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    public int hoopNumber;
    private DroneMovement drone;

    private LevelManager levelManager;

    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;

    public Material glowMaterial;
    public Material blackMaterial;
    public Material tritanopiaMaterial;
    public Material deuteranopiaMaterial;

    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        drone = GameObject.FindGameObjectWithTag("Player").GetComponent<DroneMovement>();
        Debug.Log(drone);
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        if (hoopNumber == drone.targetHoop && PlayerPrefs.GetInt("deuteranopiaOnOffToggle") == 0 && PlayerPrefs.GetInt("tritanopiaOnOffToggle") == 0)
        {
            //highlight hoop
            wall1.GetComponent<MeshRenderer>().material = glowMaterial;
        }
        else
        {
            //unhighlight hoop
            wall1.GetComponent<MeshRenderer>().material = blackMaterial;
        }
        if (hoopNumber == drone.targetHoop && PlayerPrefs.GetInt("deuteranopiaOnOffToggle") == 1 && PlayerPrefs.GetInt("tritanopiaOnOffToggle") == 0)
        {
            wall1.GetComponent<MeshRenderer>().material = deuteranopiaMaterial;

        }
        if (hoopNumber == drone.targetHoop && PlayerPrefs.GetInt("tritanopiaOnOffToggle") == 1 && PlayerPrefs.GetInt("deuteranopiaOnOffToggle") == 0)
        {
            wall1.GetComponent<MeshRenderer>().material = tritanopiaMaterial;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log("tritanopia" + PlayerPrefs.GetInt("tritanopiaOnOffToggle"));
        Debug.Log("deuteranopia" + PlayerPrefs.GetInt("deuteranopiaOnOffToggle"));
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //if colliding with player and is the target hoop 
        if (other.gameObject.CompareTag("Player") && hoopNumber == drone.targetHoop)
        {
            //check if final hoop in track
            if (hoopNumber == levelManager.lastHoopNumber)
            {
                audioManager.PlayAudio(audioManager.Leveldone);
                Debug.Log("Level Win");
                levelManager.OnLevelComplete();
            }
            else
            {
                audioManager.PlayAudio(audioManager.Hoop);
                drone.targetHoop++;
                Debug.Log("Hoop Reached");
            }
           
        }
        
    }
}
