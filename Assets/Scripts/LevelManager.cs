using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int lastHoopNumber;
    public float timer = 0;

    //ui screens
    public GameObject startScreen;
    public GameObject levelSelector;
    public GameObject hud;
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public GameObject levelOverScreen;

    public EventSystem eventSystem;

    //ui buttons
    public GameObject sceneStartBtn;
    public GameObject playBtn;
    public GameObject level1Btn;
    public GameObject settingsBtn;
    public GameObject resumeBtn;
    public GameObject continueBtn;

    // Start is called before the first frame update
    void Start()
    {
        sceneStartBtn = playBtn;
        //show start screen
        startScreen.SetActive(true);
        //hide all other uis
        levelSelector.SetActive(false);
        hud.SetActive(false);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        levelOverScreen.SetActive(false);
        //auto selectplay button
        eventSystem.firstSelectedGameObject = sceneStartBtn;
    }


    public void OnPlay()
    {
        //hide start screen
        startScreen.SetActive(false);
        //open level selector
        levelSelector.SetActive(true);
        //set selected button to level 1
        eventSystem.firstSelectedGameObject = level1Btn;

    }

    public void OnQuit()
    {
        //terminate game
        Application.Quit();
    }
    public void OnBackToStart()
    {
        //hide level selector
        levelSelector.SetActive(false);
        //open start screeb
        startScreen.SetActive(true);
        //set selected button play
        eventSystem.firstSelectedGameObject = playBtn;
    }

    public void OnLevel1()
    {
        Time.timeScale = 1; //make timer continue
        //load level 1

        //set default button to pause
        eventSystem.firstSelectedGameObject = settingsBtn;
    }
    public void OnLevel2()
    {
        Time.timeScale = 1; //make timer continue
        //load level 2

        //set default button to pause
    }
    public void OnLevel3()
    {
        Time.timeScale = 1; //make timer continue
        //load level 3

        //set default button to pause
    }

    public void OnPause()
    {
        Time.timeScale = 0; // stop timer while paused
        //show pause panel 

        //set default button to resume


    }
    public void OnResume()
    {
        Time.timeScale = 1; //make timer continue
        //hide pause panel

        //set dault button to pause
    }
    public void OnSettings()
    {
        //open setting menu

        //set panel to active

        //set default button
    }
    public void OnEndLevel()
    {
        //return to level selector

        //hide hud

        //set default button
    }
}
