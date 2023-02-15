using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Button[] levelButtons;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Texture tickMark;
    private void Start()
    {
        CheckLevel();
    }

    void CheckLevel1()
    {
        for(int i = 0; i< playerStats.playersLevelCompleted.Count; i++)
        {
            if (playerStats.playersLevelCompleted[i] == true)
            {
                
                if (i < levelButtons.Length - 1)
                {
                    levelButtons[i].gameObject.transform.GetChild(1).gameObject.GetComponentInChildren<RawImage>().texture = tickMark;
                    levelButtons[i + 1].interactable = true;
                    int j = i + 1;
                    levelButtons[j].gameObject.transform.GetChild(1).gameObject.GetComponentInChildren<RawImage>().texture = null;
                }
            }
            else
            {
                if (i<levelButtons.Length-1)
                {
                    levelButtons[i+1].interactable = false;
                }
                

            }
        }
    }

    void CheckLevel()
    {
        if (PlayerPrefs.HasKey("LevelCompleted"))
        {
            int count = 1;
            foreach(Button lvl in levelButtons)
            {
                if(count <= PlayerPrefs.GetInt("LevelCompleted"))
                {
                    lvl.gameObject.transform.GetChild(1).gameObject.GetComponentInChildren<RawImage>().texture = tickMark;
                }else if (count == PlayerPrefs.GetInt("LevelCompleted")+1)
                {
                    lvl.gameObject.transform.GetChild(1).gameObject.GetComponentInChildren<RawImage>().texture = null;
                    lvl.interactable = true;
                }
                else
                {
                    lvl.interactable = false;
                }
                count++;
            }
        }
        else
        {
            PlayerPrefs.SetInt("LevelCompleted", 0);
            CheckLevel();
        }
    }
}
