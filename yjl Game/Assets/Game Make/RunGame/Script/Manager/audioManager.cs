using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] GameObject optionPanel;

    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource bgmSource;


    void Start()
    {
        LoadVolume();
    }

    public void Sound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void SaveVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFX Volume", sfxSource.volume);
        PlayerPrefs.SetFloat("BGM Volume", bgmSource.volume);
    }

    public void LoadVolume()
    {
        bgmSource.volume = PlayerPrefs.GetFloat("BGM Volume");
        sfxSource.volume = PlayerPrefs.GetFloat("SFX Volume");
    }

    public void Close()
    {
        optionPanel.SetActive(false);
    }
}

