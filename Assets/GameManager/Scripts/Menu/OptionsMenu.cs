using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [Header("Music Mixer")]
    [SerializeField] private AudioMixer musicSoundsMixer;

    [Header("Game Mixer")]
    [SerializeField] private AudioMixer gameSoundsMixer;



    public void SetMusicVolume(float volume)
    {
        musicSoundsMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }
    public void SetGameVolume(float volume)
    {
        gameSoundsMixer.SetFloat("GameVolume", Mathf.Log10(volume) * 20);
    }

}
