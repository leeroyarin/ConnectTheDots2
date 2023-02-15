using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region References
    static AudioManager _instanceAudioManager;
    [SerializeField] Sounds musicClip;
    [SerializeField] Sounds[] audioClips;
    public DataInjector dataInjector;
    #endregion

    #region UnityMonobehavior Functions
    private void Awake()
    {
        #region Singleton
        if (_instanceAudioManager == null)
        {
            _instanceAudioManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }

    private void Start()
    {
        PlayMusic();
    }
    #endregion

    #region Checks And Plays Music Otherwise Stops
    public void PlayMusic()
    {
        if (Convert.ToBoolean(PlayerPrefs.GetInt("PlayMusic")))
        {
            musicClip.source.Play();
        }
        else
        {
            musicClip.source.Stop();
        }
    }
    #endregion

    #region SoundEffectsFunction
    public void PlayGameCompleteSFX()
    {
        if (Convert.ToBoolean(PlayerPrefs.GetInt("PlaySound")))
            Play("GameCompleted");
    }

    public void PlayGameFailureSFX()
    {
        if (Convert.ToBoolean(PlayerPrefs.GetInt("PlaySound")))
            Play("GameFailure");
    }

    public void PlayClickSoundSFX()
    {
        if (Convert.ToBoolean(PlayerPrefs.GetInt("PlaySound")))
            Play("ClickSound");
    }

    public void PlayPopUpSound()
    {
        if (Convert.ToBoolean(PlayerPrefs.GetInt("PlaySound")))
            Play("PopUp");
    }

    public void PlayCloseOffSound()
    {
        if (Convert.ToBoolean(PlayerPrefs.GetInt("PlaySound")))
            Play("CloseOff");
    }
    #endregion

    #region Plays the sound according to need
    public void Play(string audioName)
    {
        Sounds s = Array.Find(audioClips, Sounds => Sounds.audioName == audioName);
        if(s== null)
        {
            print("Failiure");

            return;
        }
        s.source.Play();
    }
    #endregion

    #region Sets volume of music and sound source
    public void SetMusicVolume(float volume)
    {
        musicClip.source.volume = volume;
    }

    public void SetSoundVolume(float volume)
    {
        foreach(Sounds s in audioClips)
        {
            s.source.volume = volume;
        }
    }
    #endregion

    //S = done
}
