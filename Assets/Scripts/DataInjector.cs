using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInjector : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] AudioManager audioManager;
    [SerializeField] SettingsManager settingsManger;
    [SerializeField] ColorSettings colorSettings;

    public PlayerStats PlayerStats
    {
        get => playerStats;
        set => playerStats = value;
    }

    public AudioManager AudioManager
    {
        get => audioManager;
        set => audioManager = value;
    }

    public SettingsManager Settings
    {
        get => settingsManger;
        set => settingsManger = value;
    }
    
    public ColorSettings ColorSettings
    {
        get => colorSettings;
        set => colorSettings = value;
    }

}
