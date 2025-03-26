using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class RRG_ColourBlindHandler : MonoBehaviour
{
    [SerializeField] private Button quitButton;

    [SerializeField] private Toggle deuteranopiaOnOffToggle;

    private bool deuteranopiaOn = false;

    private ColorBlock deuteranopiaCurrentColour;
    private Color deuteranopiaGreen;
    private Color defaultColour;

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
        }
        if (!deuteranopiaOn)
        {
            deuteranopiaCurrentColour.highlightedColor = defaultColour;
            quitButton.colors = deuteranopiaCurrentColour;
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
