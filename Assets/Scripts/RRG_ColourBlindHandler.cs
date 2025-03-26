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

    [SerializeField] private Toggle deuteranopiaOnOffToggle;

    private bool deuteranopiaOn = false;

    private ColorBlock deuteranopiaCurrentColour;
    private Color deuteranopiaGreen; //the colour used to replace green
    private Color defaultColour; //default UI colour

    // Start is called before the first frame update
    void Start()
    {
        deuteranopiaCurrentColour = quitButton.colors;
        deuteranopiaGreen.r = 0.8470588f;
        deuteranopiaGreen.g = 0.7568628f;
        deuteranopiaGreen.b = 0.3843137f;
        deuteranopiaGreen.a = 1.0f;

        defaultColour.r = 0.0f;
        defaultColour.g = 1.0f;
        defaultColour.b = 0.03921569f;
        defaultColour.a = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        deuteranopia();
        deuteranopiaTurnedOn();
    }

    public void deuteranopia()
    {
        if (deuteranopiaOn)
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


        }
        if (!deuteranopiaOn)
        {
            deuteranopiaCurrentColour.highlightedColor = defaultColour;
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
        }
    }
    public void deuteranopiaTurnedOn()
    {
        if (deuteranopiaOnOffToggle.isOn == false)
        {
            deuteranopiaOn = false;
        }
        if (deuteranopiaOnOffToggle.isOn == true)
        {
            deuteranopiaOn = true;
        }
    }
}
