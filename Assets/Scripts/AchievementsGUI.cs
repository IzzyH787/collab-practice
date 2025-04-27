using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsGUI : MonoBehaviour
{
    [SerializeField]GameObject[] Achievements;
    [SerializeField]GameObject[] CompletedTexts;
    [SerializeField] string[] AchievementsPrefNames;
    public int achieved;

    void Awake()
    {
        UpdateAchievements();
    }

    void Start()
    {
        achieved = 0;
        UpdateAchievements();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAchievements()
    {
        GameObject achievementPanel;
        GameObject completedText;
        for (int i = 0; i < 10; i++)
        {
            //reset achievements
            //PlayerPrefs.SetInt(AchievementsPrefNames[i], 0);
            if (PlayerPrefs.GetInt(AchievementsPrefNames[i]) == 1)
            {
                achievementPanel = Achievements[i];
                completedText = CompletedTexts[i];
                achievementPanel.GetComponent<Image>().color = Color.white;
                achievementPanel.GetComponent<Outline>().effectColor = Color.yellow;

                completedText.SetActive(true);
                achieved++;
            }
        }
    }
}

