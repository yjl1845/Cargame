using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager1 : Singleton<AudioManager1>
{
    [SerializeField] AudioSource sfxSource;

    public void Sound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
