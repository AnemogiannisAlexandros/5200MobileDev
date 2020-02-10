using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SourceToUse
{
    Background,
    Character,
    Environment
};

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance { get; }


    [SerializeField]
    private AudioClip[] musicClips;
    [SerializeField]
    private AudioSource[] backgroundSources;
    [SerializeField]
    private AudioSource[] characterSources;
    [SerializeField]
    private AudioSource[] environmentSources;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }
    private AudioSource LookForAvailableSource(SourceToUse source) 
    {
        switch (source) 
        {
            case SourceToUse.Background:
                foreach (AudioSource src in backgroundSources) 
                {
                    if (!src.isPlaying) 
                    {
                        return src;
                    }
                }
                break;
            case SourceToUse.Character:
                foreach (AudioSource src in characterSources)
                {
                    if (!src.isPlaying)
                    {
                        return src;
                    }
                }
                break;
            case SourceToUse.Environment:
                foreach (AudioSource src in environmentSources)
                {
                    if (!src.isPlaying)
                    {
                        return src;
                    }
                }
                break;

        }
        return null;
    }
    private AudioSource FindSource(string gameObjectSource,SourceToUse source) 
    {
        switch (source) 
        {
            case SourceToUse.Background:
                foreach (AudioSource src in backgroundSources)
                {
                    if (src.name == gameObjectSource)
                    {
                        return src;
                    }
                }
                break;
            case SourceToUse.Character:
                foreach (AudioSource src in characterSources)
                {
                    if (src.name == gameObjectSource)
                    {
                        return src;
                    }
                }
                break;
            case SourceToUse.Environment:
                foreach (AudioSource src in environmentSources)
                {
                    if (src.name == gameObjectSource)
                    {
                        return src;
                    }
                }
                break;
        }
        return null;
    }
    void Play(AudioClip clip,SourceToUse sourceType) 
    {
        AudioSource source = LookForAvailableSource(sourceType);
        if (source != null)
        {
            source.clip = clip;
            source.Play();
        }
        else 
        {
            Debug.LogError("No Available Source Registered");
        }

    }
    void PlayOneShot(AudioClip clip, SourceToUse sourceType) 
    {
        AudioSource source = LookForAvailableSource(sourceType);
        if (source != null)
        {
            source.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("No Available Source Registered");
        }
    }
    void Stop(string sourceObject,SourceToUse sourceType) 
    {
        AudioSource source = FindSource(sourceObject, sourceType);
        if (source != null) 
        {
            source.Stop();
        }
        else
        {
            Debug.LogError("No Available Source Registered");
        }
    }
    void Pause(string sourceObject, SourceToUse sourceType) 
    {
        AudioSource source = FindSource(sourceObject, sourceType);
        if (source != null)
        {
            source.Pause();
        }
        else
        {
            Debug.LogError("No Available Source Registered");
        }
    }
    void Resume(string sourceObject, SourceToUse sourceType) 
    {
        AudioSource source = FindSource(sourceObject, sourceType);
        if (source != null)
        {
            source.UnPause();
        }
        else
        {
            Debug.LogError("No Available Source Registered");
        }
    }
    
    void PlayDelayed(AudioClip clip, SourceToUse sourceType,float delay) 
    {
        AudioSource source = LookForAvailableSource(sourceType);
        if (source != null) 
        {
            source.clip = clip;
            source.PlayDelayed(delay);
        }
    }
}
