using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameplayGUI : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    //GUI value
    private float timerValue;
    private int miniSecond;
    private int second;
    private int minute;
    private string timerTextString;
    private LevelManager levelManagerScript;

    //Text GUIs
    public Text timerText;

    public bool gameStart { get; set; } = false;   //When the timer starts
    public bool gameOver { get; set; } = false;    //When the game end.

    private void Awake()
    {
        gameStart = true;
        levelManagerScript = levelManager.GetComponent<LevelManager>();
        minute = Mathf.FloorToInt(timerValue / 60);
        second = Mathf.FloorToInt(timerValue % 60);
        miniSecond = Mathf.FloorToInt(timerValue * 100 % 100);
        timerTextString = minute.ToString() +second.ToString() +miniSecond.ToString();
        timerText.text = timerTextString;
    }

    public void UpdateTimerValue()
    {
        minute = Mathf.FloorToInt(timerValue / 60);
        second = Mathf.FloorToInt(timerValue % 60);
        miniSecond = Mathf.FloorToInt(timerValue * 100 % 100);
        string formattedMinute = minute.ToString("00");
        string formattedSecond = second.ToString("00");
        string formattedMiniSecond = miniSecond.ToString("00");
        timerTextString = formattedMinute.ToString() + ":" + formattedSecond.ToString()  + ":" + formattedMiniSecond.ToString();
        timerText.text = timerTextString;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            timerValue = levelManagerScript.timer;
            if (!gameOver && timerValue < 7)
            {
                UpdateTimerValue();
            }
        }
    }
}
