using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour
{

    [SerializeField] private Toggle selfLevellingToggle;

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
    }
}
