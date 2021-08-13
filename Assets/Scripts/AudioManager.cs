using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
        }
    }

    public void Mute()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Click");

        if (s.volume > 0f)
        {
            s.volume = 0f;
            s.source.volume = s.volume;
        } 
        else
        {
            s.volume = .32f;
            s.source.volume = s.volume;
        }

        Sound a = Array.Find(sounds, sound => sound.name == "Hover");

        if (a.volume > 0f)
        {
            a.volume = 0f;
            a.source.volume = a.volume;
        }
        else
        {
            a.volume = .12f;
            a.source.volume = a.volume;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}