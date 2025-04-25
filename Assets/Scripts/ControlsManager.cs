using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour
{

    [SerializeField] private Toggle selfLevellingToggle;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("SelfLevelling"))
        {
            PlayerPrefs.SetInt("SelfLevelling", 0);
            PlayerPrefs.Save();
        }
        Debug.Log(PlayerPrefs.GetInt("SelfLevelling"));
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("SelfLevelling") == 0)
        {
            selfLevellingToggle.isOn = false;
        }
        else
        {
            selfLevellingToggle.isOn = true;
        }
    }
    public void Toggle()
    {
        Debug.Log("Toggle");
        if (selfLevellingToggle.isOn)
        {
            PlayerPrefs.SetInt("SelfLevelling", 1);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("SelfLevelling", 0);
            PlayerPrefs.Save();
        }
        Debug.Log(PlayerPrefs.GetInt("SelfLevelling"));
    }
}
