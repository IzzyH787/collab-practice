using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public int lastHoopNumber;
    public float timer = 0;
    public int timeLimitForAchievement = 120;

    //ui screens
    public GameObject sceneStartPanel;
    public GameObject startScreen;
    public GameObject levelSelector;
    public GameObject hud;
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public GameObject levelOverScreen;
    public GameObject startScreenOptionPanel;

    public GameObject achievementPanel;
    public GameObject levelIntro1;
    public GameObject levelIntro2;
    public GameObject levelIntro3;

    public EventSystem eventSystem;

    //ui buttons
    public GameObject sceneStartBtn;
    public GameObject playBtn;
    public GameObject level1Btn;
    public GameObject pauseBtn;
    public GameObject resumeBtn;
    public GameObject continueBtn;
    public GameObject closeSettingsBtn;

    public GameObject timerDisplay;
    public Text finalTimeDisplay;
    public bool showInGamePanel = true;
    float startTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        //hide all  uis
        startScreen.SetActive(!showInGamePanel);
        levelSelector.SetActive(false);
        hud.SetActive(false);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        levelOverScreen.SetActive(false);
        //show scenes start panel
        sceneStartPanel.SetActive(showInGamePanel);
        //auto selectplay button
        eventSystem.firstSelectedGameObject = sceneStartBtn;
    }


    public void OnPlay()
    {
        
        //hide start screen
        startScreen.SetActive(false);
        levelOverScreen.SetActive(false);
        achievementPanel.SetActive(false);
        //Close the level introduction panels
        levelIntro1.SetActive(false);
        levelIntro2.SetActive(false);
        levelIntro3.SetActive(false);
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
        //Hide setting screen
        startScreenOptionPanel.SetActive(false);
        //Hide achievement screen
        achievementPanel.SetActive(false);
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

        //Change the discount text if the lap is completed under two minutes
        if (completionTime <= timeLimitForAchievement)
        {

        }
        else
        {

        }
    }

    //Link to the BIRD Website
    public void OnLinkToWebsite()
    {
        Application.OpenURL("https://www.btwclub.co.uk/");
    }

    //Link to the Buy Ticket page
    public void OnGetTicket()
    {
        Application.OpenURL("https://www.btwclub.co.uk/events/bird-2025");
    }

    //Open the option menu in title screen
    public void OnStartScreenOptionMenu()
    {
        //hide paused panel
        startScreen.SetActive(false);
        //open setting menu
        startScreenOptionPanel.SetActive(true);
        //set default button to quit
        eventSystem.firstSelectedGameObject = closeSettingsBtn;
    }

    //Open the Achievement panel
    public void OnAchievement()
    {
        startScreen.SetActive(false) ;
        levelSelector.SetActive(false);
        achievementPanel.SetActive(true);
    }

    //Link to get discount code
    public void OnDiscount()
    {
        Application.OpenURL("https://www.btwclub.co.uk/events/bird-2025");
    }

    public void OnLevelIntro1()
    {
        levelSelector.SetActive(false);
        levelIntro1.SetActive(true);
    }

    public void OnLevelIntro2()
    {
        levelSelector.SetActive(false);
        levelIntro2.SetActive(true);
    }

    public void OnLevelIntro3()
    {
        levelSelector.SetActive(false);
        levelIntro3.SetActive(true);
    }
}
