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
    }

    //functions to play audio on hover
    public void hoverPlay()
    {
        if (TTSOn)
        { 
            TTSPlay.Play(0);
        }
    }
    public void hoverQuit()
    {
        if (TTSOn)
        {
            TTSQuit.Play(0);
        }
    }
    public void hoverOptions()
    {
        if (TTSOn)
        {
            TTSOptions.Play(0);
        }
    }
    public void hoverBack()
    {
        if (TTSOn) 
        { 
            TTSBack.Play(0);
        }
    }
    public void hoverLevel1()
    {
        if (TTSOn)
        {
            TTSLevel1.Play(0);
        }
    }
    public void hoverLevel2()
    {
        if (TTSOn) 
        { 
            TTSLevel2.Play(0);
        }
    }
    public void hoverLevel3()
    {
        if (TTSOn)
        {
            TTSLevel3.Play(0);
        }
    }
    public void hoverSettings()
    {
        if (TTSOn)
        {
            TTSSettings.Play(0);
        }
    }
    public void hoverResume()
    {
        if (TTSOn)
        {
            TTSResume.Play(0);
        }
    }
    public void hoverSelectLevel()
    {
        if (TTSOn)
        { 
            TTSSelectLevel.Play(0);
        }
    }
    public void hoverGetTicket()
    {
        if (TTSOn) 
        {
            TTSGetTicket.Play(0);
        }
    }
    public void unhoverPlay()
    {
        if (TTSOn)
        {
            TTSPlay.Stop();
        }
    }
    
    public void unhoverQuit()
    {
        if (TTSOn)
        {
            TTSQuit.Stop();
        }
    }
    public void unhoverOptions()
    {
        if (TTSOn)
        {
            TTSOptions.Stop();
        }
    }
    public void unhoverBack()
    {
        if (TTSOn)
        {
            TTSBack.Stop();
        }
    }
    public void unhoverLevel1()
    {
        if (TTSOn)
        {
            TTSLevel1.Stop();
        }
    }
    public void unhoverLevel2()
    {
        if (TTSOn)
        {
            TTSLevel2.Stop();
        }
    }
    public void unhoverLevel3()
    {
        if (TTSOn)
        {
            TTSLevel3.Stop();
        }
    }
    public void unhoverSettings()
    {
        if (TTSOn)
        {
            TTSSettings.Stop();
        }
    }

    //function ran on toggle switch
    public void TTSTurnedOn()
    {
        if (TTSOnOffToggle.isOn == false)
        {
            TTSOn = false;
        }
        if (TTSOnOffToggle.isOn == true)
        {
            TTSOn = true;
        }
    }

}
