using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class RRG_ColourBlindHandler : MonoBehaviour
{
    [SerializeField] private Button quitButton;//settings quit
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButtonMM;//main menu quit
    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    [SerializeField] private Button levelSelectorBackButton;
    [SerializeField] private Button achievementsBackButton;
    [SerializeField] private Button level1BackButton;
    [SerializeField] private Button level1LevelPlayButton;
    [SerializeField] private Button level2BackButton;
    [SerializeField] private Button level2LevelPlayButton;
    [SerializeField] private Button level3BackButton;
    [SerializeField] private Button level3LevelPlayButton;
    [SerializeField] private Button homeWebPageButton;
    [SerializeField] private Button achievementsButton;
    [SerializeField] private Button ticketsButton;
    [SerializeField] private Button pauseResumeButton;
    [SerializeField] private Button pauseSettingsButton;
    [SerializeField] private Button pauseQuitButton;
    [SerializeField] private Button levelOverLevelSelectButton;
    [SerializeField] private Button levelOverGetTicketButton;
    [SerializeField] private Button levelOverAchievementsButton;
    [SerializeField] private Button HUDPauseButton;

    [SerializeField] private Toggle deuteranopiaOnOffToggle;
    [SerializeField] private Toggle tritanopiaOnOffToggle;

    private bool deuteranopiaOn = false;
    private bool tritanopiaOn = false;
    private bool defaultColourUIBool = true;

    private ColorBlock deuteranopiaCurrentColour;
    private Color deuteranopiaGreen; //the colour used to replace green

    private ColorBlock defaultColourCurrentColour;
    private Color defaultColour; //default UI colour

    private ColorBlock tritanopiaCurrentColour;
    private Color tritanopiaGreen; //the colour used to replace green

    // Start is called before the first frame update
    void Start()
    {
        deuteranopiaCurrentColour = quitButton.colors;
        deuteranopiaGreen.r = 0.8470588f;
        deuteranopiaGreen.g = 0.7568628f;
        deuteranopiaGreen.b = 0.3843137f;
        deuteranopiaGreen.a = 1.0f;

        tritanopiaCurrentColour = playButton.colors;
        tritanopiaGreen.r = 0.227451f;
        tritanopiaGreen.g = 0.8784314f;
        tritanopiaGreen.b = 0.8627451f;
        tritanopiaGreen.a = 1.0f;

        defaultColourCurrentColour = settingsButton.colors;
        defaultColour.r = 0.0f;
        defaultColour.g = 1.0f;
        defaultColour.b = 0.03921569f;
        defaultColour.a = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        deuteranopia();
        //deuteranopiaTurnedOn();

        tritanopia();
        //tritanopiaTurnedOn();

        if (defaultColourUIBool)
        {
            defaultColourCurrentColour.highlightedColor = defaultColour;
            quitButton.colors = defaultColourCurrentColour;
            playButton.colors = defaultColourCurrentColour;
            settingsButton.colors = defaultColourCurrentColour;
            quitButtonMM.colors = defaultColourCurrentColour;
            level1Button.colors = defaultColourCurrentColour;
            level2Button.colors = defaultColourCurrentColour;
            level3Button.colors = defaultColourCurrentColour;
            levelSelectorBackButton.colors = defaultColourCurrentColour;
            achievementsBackButton.colors = defaultColourCurrentColour;
            level1BackButton.colors = defaultColourCurrentColour;
            level1LevelPlayButton.colors = defaultColourCurrentColour;
            level2BackButton.colors = defaultColourCurrentColour;
            level2LevelPlayButton.colors = defaultColourCurrentColour;
            level3BackButton.colors = defaultColourCurrentColour;
            level3LevelPlayButton.colors = defaultColourCurrentColour;
            homeWebPageButton.colors = defaultColourCurrentColour;
            achievementsButton.colors = defaultColourCurrentColour;
            ticketsButton.colors = defaultColourCurrentColour;
            pauseResumeButton.colors = defaultColourCurrentColour;
            pauseSettingsButton.colors = defaultColourCurrentColour;
            pauseQuitButton.colors = defaultColourCurrentColour;
            levelOverAchievementsButton.colors = defaultColourCurrentColour;
            levelOverGetTicketButton.colors = defaultColourCurrentColour;
            levelOverLevelSelectButton.colors = defaultColourCurrentColour;
            HUDPauseButton.colors = defaultColourCurrentColour;
        }

        //running in update to avoid bug: when player ticks a colour blind mode when a mode is already selected the colour will default to green.
        if (tritanopiaOnOffToggle.isOn == true)
        {
            tritanopiaOn = true;
            defaultColourUIBool = false;
            deuteranopiaOnOffToggle.isOn = false;
            deuteranopiaOn = false;
            PlayerPrefs.SetInt("tritanopiaOnOffToggle", 1);
            PlayerPrefs.SetInt("deuteranopiaOnOffToggle", 0);
        }
        if (tritanopiaOnOffToggle.isOn == false)
        {
            PlayerPrefs.SetInt("tritanopiaOnOffToggle", 0);
        }
        if (deuteranopiaOnOffToggle.isOn == true)
        {
            deuteranopiaOn = true;
            defaultColourUIBool = false;
            tritanopiaOnOffToggle.isOn = false;
            tritanopiaOn = false;
            PlayerPrefs.SetInt("deuteranopiaOnOffToggle", 1);
            PlayerPrefs.SetInt("tritanopiaOnOffToggle", 0);
        }
        if (deuteranopiaOnOffToggle.isOn == false)
        {
            PlayerPrefs.SetInt("deuteranopiaOnOffToggle", 0);
        }
    }

    public void deuteranopia()
    {
        if (PlayerPrefs.GetInt("deuteranopiaOnOffToggle") == 1)
        {
            deuteranopiaCurrentColour.highlightedColor = deuteranopiaGreen;
            quitButton.colors = deuteranopiaCurrentColour;
            playButton.colors = deuteranopiaCurrentColour;
            settingsButton.colors = deuteranopiaCurrentColour;
            quitButtonMM.colors = deuteranopiaCurrentColour;
            level1Button.colors = deuteranopiaCurrentColour;
            level2Button.colors = deuteranopiaCurrentColour;
            level3Button.colors = deuteranopiaCurrentColour;
            levelSelectorBackButton.colors = deuteranopiaCurrentColour;
            achievementsBackButton.colors = deuteranopiaCurrentColour;
            level1BackButton.colors = deuteranopiaCurrentColour;
            level1LevelPlayButton.colors = deuteranopiaCurrentColour;
            level2BackButton.colors = deuteranopiaCurrentColour;
            level2LevelPlayButton.colors = deuteranopiaCurrentColour;
            level3BackButton.colors = deuteranopiaCurrentColour;
            level3LevelPlayButton.colors = deuteranopiaCurrentColour;
            homeWebPageButton.colors = deuteranopiaCurrentColour;
            achievementsButton.colors = deuteranopiaCurrentColour;
            ticketsButton.colors = deuteranopiaCurrentColour;
            pauseResumeButton.colors = deuteranopiaCurrentColour;
            pauseSettingsButton.colors = deuteranopiaCurrentColour;
            pauseQuitButton.colors = deuteranopiaCurrentColour;
            levelOverAchievementsButton.colors = deuteranopiaCurrentColour;
            levelOverGetTicketButton.colors = deuteranopiaCurrentColour;
            levelOverLevelSelectButton.colors = deuteranopiaCurrentColour;
            HUDPauseButton.colors = deuteranopiaCurrentColour;
        }
    }
    public void tritanopia()
    {
        if (PlayerPrefs.GetInt("tritanopiaOnOffToggle") == 1)
        {
            tritanopiaCurrentColour.highlightedColor = tritanopiaGreen;
            quitButton.colors = tritanopiaCurrentColour;
            playButton.colors = tritanopiaCurrentColour;
            settingsButton.colors = tritanopiaCurrentColour;
            quitButtonMM.colors = tritanopiaCurrentColour;
            level1Button.colors = tritanopiaCurrentColour;
            level2Button.colors = tritanopiaCurrentColour;
            level3Button.colors = tritanopiaCurrentColour;
            levelSelectorBackButton.colors = tritanopiaCurrentColour;
            achievementsBackButton.colors = tritanopiaCurrentColour;
            level1BackButton.colors = tritanopiaCurrentColour;
            level1LevelPlayButton.colors = tritanopiaCurrentColour;
            level2BackButton.colors = tritanopiaCurrentColour;
            level2LevelPlayButton.colors = tritanopiaCurrentColour;
            level3BackButton.colors = tritanopiaCurrentColour;
            level3LevelPlayButton.colors = tritanopiaCurrentColour;
            homeWebPageButton.colors = tritanopiaCurrentColour;
            achievementsButton.colors = tritanopiaCurrentColour;
            ticketsButton.colors = tritanopiaCurrentColour;
            pauseResumeButton.colors = tritanopiaCurrentColour;
            pauseSettingsButton.colors = tritanopiaCurrentColour;
            pauseQuitButton.colors = tritanopiaCurrentColour;
            levelOverAchievementsButton.colors = tritanopiaCurrentColour;
            levelOverGetTicketButton.colors = tritanopiaCurrentColour;
            levelOverLevelSelectButton.colors = tritanopiaCurrentColour;
            HUDPauseButton.colors = tritanopiaCurrentColour;
        }
    }
    public void deuteranopiaTurnedOn()
    {
        if (deuteranopiaOnOffToggle.isOn == false)
        {
            deuteranopiaOn = false;
            tritanopiaOn = false;
            defaultColourUIBool = true;
            PlayerPrefs.SetInt("deuteranopiaOnOffToggle", 0);
        }
        if (deuteranopiaOnOffToggle.isOn == true)
        {
            deuteranopiaOn = true;
            defaultColourUIBool = false;
            tritanopiaOnOffToggle.isOn = false;
            tritanopiaOn = false;
            PlayerPrefs.SetInt("deuteranopiaOnOffToggle", 1);
            PlayerPrefs.SetInt("tritanopiaOnOffToggle", 0);
        }
    }

    public void tritanopiaTurnedOn()
    {
        if (tritanopiaOnOffToggle.isOn == false)
        {
            tritanopiaOn = false;
            deuteranopiaOn = false;
            defaultColourUIBool = true;
            PlayerPrefs.SetInt("tritanopiaOnOffToggle", 0);
        }
        if (tritanopiaOnOffToggle.isOn == true)
        {
            tritanopiaOn = true;
            defaultColourUIBool = false;
            deuteranopiaOnOffToggle.isOn = false;
            deuteranopiaOn = false;
            PlayerPrefs.SetInt("tritanopiaOnOffToggle", 1);
            PlayerPrefs.SetInt("deuteranopiaOnOffToggle", 0);
        }
    }
}
