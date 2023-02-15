using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerGameStatus", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public string playerName;
    public int playersLevelCompletion;
    public List<bool> playersLevelCompleted = new() ;
    public int playerLevelRestartCount;
    public int playerLevelFailureCount;
    public int totalGameLevels;
    public bool playMusic;
    [Range(0, 1f)]
    public float musicVolumeLevel;

    public bool playAudio;
    [Range(0, 0.35f)]
    public float audioVolumeLevel;

    public Gradient lineColor;
}
