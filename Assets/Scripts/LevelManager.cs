using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int lastHoopNumber;
    public float timer = 0;
    public int timeQualifiedToGetDiscount = 120;

    //ui screens
    public GameObject sceneStartPanel;
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
    public GameObject pauseBtn;
    public GameObject resumeBtn;
    public GameObject continueBtn;
    public GameObject closeSettingsBtn;
    public GameObject buyTicketBtn;
    public Text discountReminder;
    public GameObject discounBtn;

    public GameObject timerDisplay;
    public Text finalTimeDisplay;
    float startTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        //hide all  uis
        startScreen.SetActive(false);
        levelSelector.SetActive(false);
        hud.SetActive(false);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        levelOverScreen.SetActive(false);
        //show scenes start panel
        sceneStartPanel.SetActive(true);
        //auto selectplay button
        eventSystem.firstSelectedGameObject = sceneStartBtn;
    }


    public void OnPlay()
    {
        //hide start screen
        startScreen.SetActive(false);
        levelOverScreen.SetActive(false);
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
        SceneManager.LoadScene(1);
        //set default button to pause
    }
    public void OnLevel2()
    {
        Time.timeScale = 1; //make timer continue
        //load level 2
        SceneManager.LoadScene(2);
    }
    public void OnLevel3()
    {
        Time.timeScale = 1; //make timer continue
        //load level 3
        SceneManager.LoadScene(3);
        //set default button to pause
    }

    public void OnPause()
    {
        Time.timeScale = 0; // stop timer while paused
        //hide hud
        hud.SetActive(false);
        //show pause panel 
        pausePanel.SetActive(true);
        //set default button to resume
        eventSystem.firstSelectedGameObject = resumeBtn;

    }
    public void OnResume()
    {
        Time.timeScale = 1; //make timer continue
        //hide pause panel
        pausePanel.SetActive(false);
        //show hud
        hud.SetActive(true);
        //set dault button to pause
        eventSystem.firstSelectedGameObject = pauseBtn;
    }
    public void OnSettings()
    {
        //hide paused panel
        pausePanel.SetActive(false);
        //open setting menu
        settingsPanel.SetActive(true);
        //set default button to quit
        eventSystem.firstSelectedGameObject = closeSettingsBtn;
    }
    public void OnEndLevel()
    {
        //hide paused menu
        pausePanel.SetActive(false);
        //hide hud
        hud.SetActive(false);
        //return to level selector
        OnPlay();
    }
    public void OnCloseSetting()
    {
        //hide settings
        settingsPanel.SetActive(false);
        //show paused panel
        pausePanel.SetActive(true);
        //set deault button to resume
        eventSystem.firstSelectedGameObject = resumeBtn;
    }
    public void OnLevelComplete()
    {
        Time.timeScale = 0; //pause timer
        hud.SetActive(false); //hide hud
                                           //show level over screen
        levelOverScreen.SetActive(true);
        //set default button
        eventSystem.firstSelectedGameObject = continueBtn;
        //display completion time on screen
        float completionTime = Time.time - startTime;
        int minutes = (int)(completionTime / 60);
        int seconds = (int)(completionTime - (minutes * 60));
        string displayText = "";
        if (seconds > 9)
        {
            displayText = minutes + ":" + seconds;
        }
        else
        {
            displayText = minutes + ":0" + seconds;
        }
        finalTimeDisplay.text = displayText;

        string discountReminderText = "";
        //Change the discount text if the lap is completed under two minutes
        if (completionTime <= timeQualifiedToGetDiscount)
        {
            discountReminderText = "Finish the lap under two minutes? ";
            discounBtn.SetActive(true);
        }
        else
        {
            discountReminderText = "Finish the lap in two minutes and get a discount!";
            discounBtn.SetActive(false);
        }
        discountReminder.text = discountReminderText;
    }
}
