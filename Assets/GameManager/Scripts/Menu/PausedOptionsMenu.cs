using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;

public class PausedOptionsMenu : MonoBehaviour
{
    [Header("Music Mixer")]
    [SerializeField] private AudioMixer musicSoundsMixer;

    [Header("Game Mixer")]
    [SerializeField] private AudioMixer gameSoundsMixer;

    [Header("Music Player")]
    [SerializeField] private AudioSource musicPlayer;



    public void SetMusicVolume(float volume)
    {
        musicSoundsMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }
    public void SetGameVolume(float volume)
    {
        gameSoundsMixer.SetFloat("GameVolume", Mathf.Log10(volume) * 20);
    }

    public void SetMusic(AudioClip selectedMusic)
    {
        musicPlayer.clip = selectedMusic;
        musicPlayer.Play();
    }

}
