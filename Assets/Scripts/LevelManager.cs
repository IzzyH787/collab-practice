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
    public int levelNum;
    public AchievementManager achievementManager;

    public bool hitlava;

    [SerializeField] private Toggle deuteranopiaOnOffToggle;
    [SerializeField] private Toggle tritanopiaOnOffToggle;
    [SerializeField] private Toggle selfLevellingToggle;
    [SerializeField] private Toggle TTSToggle;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        // Restore level number
        if (PlayerPrefs.HasKey("levelNum"))
        {
            levelNum = PlayerPrefs.GetInt("levelNum");
        }

        //hide all  uis
        startScreen.SetActive(!showInGamePanel);
        levelSelector.SetActive(false);
        hud.SetActive(false);
        pausePanel.SetActive(false);
        startScreenOptionPanel.SetActive(false);
        //settingsPanel.SetActive(false);
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
        Application.OpenURL("https://jiusuia.github.io/web_game/");
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
        PlayerPrefs.SetInt("levelNum", 1);
        PlayerPrefs.Save();
        //load level 1
        SceneManager.LoadScene(1);
        //set default button to pause
    }
    public void OnLevel2()
    {
        Time.timeScale = 1; //make timer continue
        PlayerPrefs.SetInt("levelNum", 2);
        PlayerPrefs.Save();
        //load level 2
        SceneManager.LoadScene(2);
    }
    public void OnLevel3()
    {
        Time.timeScale = 1; //make timer continue
        PlayerPrefs.SetInt("levelNum", 3);
        PlayerPrefs.Save();
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
        startScreenOptionPanel.SetActive(true);
        //settingsPanel.SetActive(true);
        //set default button to quit
        eventSystem.firstSelectedGameObject = closeSettingsBtn;
        //set toggles up 
        if (checkPref("deuteranopiaOnOffToggle"))
        {
            deuteranopiaOnOffToggle.isOn = true;
        }
        if (checkPref("tritanopiaOnOffToggle"))
        {
            deuteranopiaOnOffToggle.isOn = true;
        }
        if (checkPref("SelfLevelling"))
        {
            selfLevellingToggle.isOn = true;
        }
        if (checkPref("TTSOn"))
        {
            TTSToggle.isOn = true;
        }
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
        startScreenOptionPanel.SetActive(true);
        //show paused panel
        pausePanel.SetActive(true);
        //set deault button to resume
        eventSystem.firstSelectedGameObject = resumeBtn;
    }
    public void OnLevelComplete()
    {
        Debug.Log("OnLevelComplete() called");
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
        Debug.Log("Current level number: " + levelNum);
        //Change the discount text if the lap is completed under two minutes

        /////////////CHECKS FOR LEVELS INDIVIDUALLY COMPLETE/////////////////
        ///
        ////////LEVEL 1////////////
        if (levelNum == 1)
        {
            Debug.Log("l1 won");
            PlayerPrefs.SetInt("IsLv1Complete", 1); //level 1 complete
            PlayerPrefs.Save();
            //acro mode 
            if (PlayerPrefs.GetInt("SelfLeveling") == 0)
            {
                PlayerPrefs.SetInt("IsLv1CompleteAcro", 1);
                PlayerPrefs.Save();
            }
            //self levelling mode
            else
            {
                PlayerPrefs.SetInt("IsLv1CompleteSL", 1);
                PlayerPrefs.Save();
            }
            ////////CHECK IF COMPLETED IN TIME///////////
            if (completionTime <= 60)
            {
                PlayerPrefs.SetInt("IsLv1CompleteInTimer", 1);
                PlayerPrefs.SetInt("IsLv1CompleteInMin", 1);
                PlayerPrefs.Save();
            }
            else if (completionTime <= timeLimitForAchievement)
            {
                PlayerPrefs.SetInt("IsLv1CompleteInTimer", 1);
                PlayerPrefs.Save();
            }
        }


        ////////LEVEL 2////////////
        else if (levelNum == 2)
        {
            Debug.Log("l2 won");
            PlayerPrefs.SetInt("IsLv2Complete", 1);
            PlayerPrefs.Save();
            //acro mode 
            if (PlayerPrefs.GetInt("SelfLeveling") == 0)
            {
                PlayerPrefs.SetInt("IsLv2CompleteAcro", 1);
                PlayerPrefs.Save();
            }
            //self levelling mode
            else
            {
                PlayerPrefs.SetInt("IsLv2CompleteSL", 1);
                PlayerPrefs.Save();
            }
            ////////CHECK IF COMPLETED IN TIME///////////
            if (completionTime <= 60)
            {
                PlayerPrefs.SetInt("IsLv2CompleteInTimer", 1);
                PlayerPrefs.SetInt("IsLv2CompleteInMin", 1);
                PlayerPrefs.Save();
            }
            else if (completionTime <= timeLimitForAchievement)
            {
                PlayerPrefs.SetInt("IsLv2CompleteInTimer", 1);
                PlayerPrefs.Save();
            }
        }


        ////////LEVEL 3////////////
        else if (levelNum == 3)
        {
            Debug.Log("l3 won");
            if (!hitlava)
            {
                PlayerPrefs.SetInt("DidntHitLava", 1);
                Debug.Log("Achievement- no lava");
            }
            PlayerPrefs.SetInt("IsLv3Complete", 1);
            PlayerPrefs.Save();
            //acro mode 
            if (PlayerPrefs.GetInt("SelfLeveling") == 0)
            {
                PlayerPrefs.SetInt("IsLv3CompleteAcro", 1);
                PlayerPrefs.Save();
            }
            //self levelling mode
            else
            {
                PlayerPrefs.SetInt("IsLv3CompleteSL", 1);
                PlayerPrefs.Save();
            }
            ////////CHECK IF COMPLETED IN TIME///////////
            if (completionTime <= 60)
            {
                PlayerPrefs.SetInt("IsLv3CompleteInTimer", 1);
                PlayerPrefs.SetInt("IsLv3CompleteInMin", 1);
                PlayerPrefs.Save();
            }
            else if (completionTime <= timeLimitForAchievement)
            {
                PlayerPrefs.SetInt("IsLv3CompleteInTimer", 1);
                PlayerPrefs.Save();
            }
        }
            /////////////////////CHECK IF ALL LEVELS COMPLETE//////////////////////////
            if (PlayerPrefs.GetInt("IsLv1Complete") == 1 && PlayerPrefs.GetInt("IsLv2Complete") == 1 && PlayerPrefs.GetInt("IsLv3Complete") == 1)
            {
                PlayerPrefs.SetInt("IsAllLevelsComplete", 1);
                PlayerPrefs.Save();
            //////////////////CHECK IF ALL LEVELS COMPLETE IN BOTH MODES/////////////////////
            if (checkPref("IsLv1CompleteAcro") && checkPref("IsLv2CompleteAcro") && checkPref("IsLv3CompleteAcro") && checkPref("IsLv1CompleteSL") && checkPref("IsLv2CompleteSL") && checkPref("IsLv3CompleteSL"))
                {
                    PlayerPrefs.SetInt("IsAllModesComplete", 1);
                    PlayerPrefs.Save();
            }
                ///////////////CHECK IF ALL LEVELS COMPLETE IN 1 MIN//////////////////
                if (checkPref("IsLv1CompleteInMin") && checkPref("IsLv2CompleteInMin") && checkPref("IsLv3CompleteInMin"))
                {
                    PlayerPrefs.SetInt("IsAllLevelsCompletein1min", 1);
                    PlayerPrefs.Save();
                }
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

    bool checkPref(string prefName)
    {
        return (PlayerPrefs.GetInt(prefName) == 1);
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
