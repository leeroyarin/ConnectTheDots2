using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] DataInjector dataInjector;

    [SerializeField] Slider AudioVolumeSlider;
    [SerializeField] Slider MusicVolumeSlider;
    [SerializeField] Slider brightnessSlider, contrastSlider, saturationSlider;

    [SerializeField] TMP_InputField inputName;
    [SerializeField] Image AudioImage;
    [SerializeField] Image MusicImage;

    [SerializeField] Color buttonTrue;
    [SerializeField] Color buttonNotTrue;

    private void Awake()
    {
        
        dataInjector = FindObjectOfType<DataInjector>();

        dataInjector.ColorSettings.Awake();
        dataInjector.ColorSettings.Start();

    }
    private void Start()
    {
        inputName.text = PlayerPrefs.GetString("PlayerName");
        CheckSound(Convert.ToBoolean(PlayerPrefs.GetInt("PlaySound")));
        CheckMusic(Convert.ToBoolean(PlayerPrefs.GetInt("PlayMusic")));      
    }

    //    [ContextMenu("FunctionName")]

    public void StoreName()
    {
        PlayerPrefs.SetString("PlayerName",inputName.text);
    }

    public void OnSetColor()//calls function
    {
        dataInjector.ColorSettings.ColorUpdate();
    }

    public void OnAudioActivation()
    {
        if(Convert.ToBoolean(PlayerPrefs.GetInt("PlaySound")) == false)
        {
            PlayerPrefs.SetInt("PlaySound", Convert.ToInt32(true));
            CheckSound(true);
            return;
        }
        if(Convert.ToBoolean(PlayerPrefs.GetInt("PlaySound")) == true)
        {
            PlayerPrefs.SetInt("PlaySound", Convert.ToInt32(false));
            CheckSound(false);
            return;
        }

    }

    public void OnMusicActivation()
    {
        if (Convert.ToBoolean(PlayerPrefs.GetInt("PlayMusic")) == false)
        {
            PlayerPrefs.SetInt("PlayMusic", Convert.ToInt32(true));
            dataInjector.AudioManager.PlayMusic();
            CheckMusic(true);
            return;
        }
        if (Convert.ToBoolean(PlayerPrefs.GetInt("PlayMusic")) == true)
        {
            PlayerPrefs.SetInt("PlayMusic", Convert.ToInt32(false));
            dataInjector.AudioManager.PlayMusic();
            CheckMusic(false);
            return;
        }

    }

    void CheckSound(bool SFXActivate)
    {
        if (SFXActivate)
        {
            AudioImage.color = buttonTrue;
            AudioVolumeSlider.gameObject.SetActive(true);
            SetAudioSlider(PlayerPrefs.GetFloat("SoundVolume"));
        }
        else
        {
            AudioImage.color = buttonNotTrue;
            AudioVolumeSlider.gameObject.SetActive(false);
        }
    }

    void CheckMusic(bool MusicActivate)
    {
        if (MusicActivate)
        {
            MusicImage.color = buttonTrue;
            MusicVolumeSlider.gameObject.SetActive(true);
            SetMusicSlider(PlayerPrefs.GetFloat("MusicVolume"));
        }
        else
        {
            MusicImage.color = buttonNotTrue;
            MusicVolumeSlider.gameObject.SetActive(false);
        }
    }

    void SetMusicSlider(float volumeLevel) => MusicVolumeSlider.value = volumeLevel;

    void SetAudioSlider(float volumeLevel) => AudioVolumeSlider.value = volumeLevel;


    public void OnSetMusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicVolumeSlider.value);
        dataInjector.AudioManager.SetMusicVolume(MusicVolumeSlider.value);
    }

    public void OnSetSoundVolume()
    {
        PlayerPrefs.SetFloat("SoundVolume", AudioVolumeSlider.value);
        dataInjector.AudioManager.SetSoundVolume(AudioVolumeSlider.value);
    }

    public Slider GetBrightness()
    {

        return brightnessSlider;
    }

    public Slider GetContrast()
    {
        return contrastSlider;
    }

    public Slider GetSaturation()
    {
        return saturationSlider;
    }
}
