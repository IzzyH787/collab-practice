using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RRG_TTSHandler : MonoBehaviour
{
    [SerializeField] private AudioSource TTSPlay;
    [SerializeField] private AudioSource TTSQuit;
    [SerializeField] private AudioSource TTSOptions;
    [SerializeField] private AudioSource TTSBack;
    [SerializeField] private AudioSource TTSLevel1;
    [SerializeField] private AudioSource TTSLevel2;
    [SerializeField] private AudioSource TTSLevel3;
    [SerializeField] private AudioSource TTSSettings;
    [SerializeField] private AudioSource TTSResume;
    [SerializeField] private AudioSource TTSSelectLevel;
    [SerializeField] private AudioSource TTSGetTicket;

    [SerializeField] private Toggle TTSOnOffToggle;

    private bool TTSOn = false;

    private void Update()
    {
        TTSTurnedOn();

        Debug.Log(PlayerPrefs.GetInt("TTSOn"));
    }

    //functions to play audio on hover
    public void hoverPlay()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        { 
            TTSPlay.Play();
        }
    }
    public void hoverQuit()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSQuit.Play(0);
        }
    }
    public void hoverOptions()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSOptions.Play(0);
        }
    }
    public void hoverBack()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1) 
        { 
            TTSBack.Play(0);
        }
    }
    public void hoverLevel1()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSLevel1.Play(0);
        }
    }
    public void hoverLevel2()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1) 
        { 
            TTSLevel2.Play(0);
        }
    }
    public void hoverLevel3()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSLevel3.Play(0);
        }
    }
    public void hoverSettings()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSSettings.Play(0);
        }
    }
    public void hoverResume()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSResume.Play(0);
        }
    }
    public void hoverSelectLevel()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        { 
            TTSSelectLevel.Play(0);
        }
    }
    public void hoverGetTicket()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1) 
        {
            TTSGetTicket.Play(0);
        }
    }
    public void unhoverPlay()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSPlay.Stop();
        }
    }
    
    public void unhoverQuit()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSQuit.Stop();
        }
    }
    public void unhoverOptions()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSOptions.Stop();
        }
    }
    public void unhoverBack()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSBack.Stop();
        }
    }
    public void unhoverLevel1()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSLevel1.Stop();
        }
    }
    public void unhoverLevel2()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSLevel2.Stop();
        }
    }
    public void unhoverLevel3()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSLevel3.Stop();
        }
    }
    public void unhoverSettings()
    {
        if (PlayerPrefs.GetInt("TTSOn") == 1)
        {
            TTSSettings.Stop();
        }
    }

    //function ran on toggle switch
    public void TTSTurnedOn()
    {
        /* if (TTSOnOffToggle.isOn == false)
         {
             TTSOn = false;
         }
         if (TTSOnOffToggle.isOn == true)
         {
             TTSOn = true;
         }*/
        if (TTSOnOffToggle.isOn)
        {
            PlayerPrefs.SetInt("TTSOn", 1);
            PlayerPrefs.Save();
        }
        if (TTSOnOffToggle.isOn == false)
        {
            PlayerPrefs.SetInt("TTSOn", 0);
            PlayerPrefs.Save();
        }
    }

}
