using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject confirmExitMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public GameObject gameCompleteMenu;
    public GameObject gameOverMenu;

    DataInjector dataInjector;
    private void Awake()
    {
        dataInjector = FindObjectOfType<DataInjector>();
    }
    
    #region HIDE/SHOW UI

    public void OnShowSettings()
    {
        settingsMenu.SetActive(true);
        dataInjector.AudioManager.PlayClickSoundSFX();
        dataInjector.AudioManager.PlayPopUpSound();

    }
    public void OnHideSettings()
    {
        settingsMenu.SetActive(false);
        dataInjector.AudioManager.PlayClickSoundSFX();
        dataInjector.AudioManager.PlayCloseOffSound();


    }

    public void OnPlayGame()
    {
        SceneManager.LoadScene("LevelSelection");
        dataInjector.AudioManager.PlayClickSoundSFX();

    }

    public void OnExitGame()
    {
        confirmExitMenu.SetActive(true);
        dataInjector.AudioManager.PlayClickSoundSFX();
        dataInjector.AudioManager.PlayPopUpSound();

    }

    public void OnSureEXit()
    {
        Application.Quit();
        dataInjector.AudioManager.PlayClickSoundSFX();

    }

    public void OnCancelExit()
    {
        confirmExitMenu.SetActive(false);
        dataInjector.AudioManager.PlayClickSoundSFX();
        dataInjector.AudioManager.PlayCloseOffSound();
    }

    public void OnPauseClick()
    {
        dataInjector.AudioManager.PlayClickSoundSFX();
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        dataInjector.AudioManager.PlayPopUpSound();
    }

    public void OnPauseExit()
    {
        dataInjector.AudioManager.PlayClickSoundSFX();
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        dataInjector.AudioManager.PlayCloseOffSound();

    }

    public void OnRestartClick()
    {
        dataInjector.AudioManager.PlayClickSoundSFX();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (PlayerPrefs.HasKey("PlayerRetry"))
        {
            PlayerPrefs.SetInt("PlayerRetry", PlayerPrefs.GetInt("PlayerRetry") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("PlayerRetry", 1);
        }
    }

    public void OnGameCompleted()
    {
        gameCompleteMenu.SetActive(true);
        if (PlayerPrefs.HasKey("PlayerSuccess"))
        {
            PlayerPrefs.SetInt("PlayerSuccess", PlayerPrefs.GetInt("PlayerSuccess") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("PlayerSuccess", 1);
        }
        PlayerPrefs.SetInt("LevelCompleted", SceneManager.GetActiveScene().buildIndex);
    }

    public void OnGameOver()
    {
        gameOverMenu.SetActive(true);
        if (PlayerPrefs.HasKey("PlayerFails"))
        {
            PlayerPrefs.SetInt("PlayerFails", 1);
        }
        PlayerPrefs.SetInt("PlayerFails",PlayerPrefs.GetInt("PlayerFails")+1);
    }

    public void OnExitToMenu()
    {
        dataInjector.AudioManager.PlayClickSoundSFX();
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene("Start");
    }

    public void OnNextClick()
    {
        dataInjector.AudioManager.PlayClickSoundSFX();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion

    public void OnLevelSelect(int lvlNumber)
    {
        dataInjector.AudioManager.PlayClickSoundSFX();

        SceneManager.LoadScene(lvlNumber);
    }

    public void OnLevelMenu()
    {
        dataInjector.AudioManager.PlayClickSoundSFX();
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene("LevelSelection");
    }


}
