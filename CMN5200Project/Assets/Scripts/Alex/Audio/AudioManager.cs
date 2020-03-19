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

    public static AudioManager Instance { get { return _instance; } }

    [SerializeField]
    private bool playFolleys;
    [Tooltip("All available Music clips")]
    [SerializeField]
    private AudioClip[] musicClips;
    [SerializeField]
    [Tooltip("All available Folley clips")]
    private AudioClip[] folleyClips;
    [SerializeField]
    [Header("Character Clips")]
    private AudioClip[] footsteps;
    [SerializeField]
    private AudioClip[] jumpFallLand;
    [Tooltip("Sources playing background clips such as Music/Drones/Folley")]
    [SerializeField]
    private AudioSource[] backgroundSources;
    [Tooltip("Sources playing Character sounds such as footsteps,hits,etc")]
    [SerializeField]
    private AudioSource[] characterSources;
    [Tooltip("Sources playing Environment clips such as Branch Cracks / Animal squeaks etc")]
    [SerializeField]
    private AudioSource[] environmentSources;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        PlayeRandomFolleySounds();
    }
    public AudioClip[] GetMusicClips()
    {
        return musicClips;
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
    private AudioSource FindSource(string gameObjectSource, SourceToUse source)
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
    public void PlayCharacterFootsteps()
    {
        AudioSource source = LookForAvailableSource(SourceToUse.Character);
        source.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)]);
    }
    public void PlayCharacterJump(int part)
    {
        AudioSource source = LookForAvailableSource(SourceToUse.Character);
        source.PlayOneShot(jumpFallLand[part]);
    }
    #region Public Methods
    public void PlayLooping(AudioClip clip, SourceToUse sourceType)
    {
        AudioSource source = LookForAvailableSource(sourceType);
        if(source != null)
        {
            source.loop = true;
            source.clip = clip;
            if (!source.isPlaying)
            {
                source.Play();
            }
            else
            {
                source.loop = false;

            }

        }
        else
        {
            Debug.LogError("No Available Source Registered");
        }
    }
    public void Play(AudioClip clip, SourceToUse sourceType)
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
    public void PlayOneShot(AudioClip clip, SourceToUse sourceType)
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
    public void Stop(string sourceObject, SourceToUse sourceType)
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
    public void Pause(string sourceObject, SourceToUse sourceType)
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
    public void Resume(string sourceObject, SourceToUse sourceType)
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

    public void PlayDelayed(AudioClip clip, SourceToUse sourceType, float delay)
    {
        AudioSource source = LookForAvailableSource(sourceType);
        if (source != null)
        {
            source.clip = clip;
            source.PlayDelayed(delay);
        }
    }
    public void PlayeOnSource(string sourceObject, SourceToUse sourceType, AudioClip clip)
    {
        AudioSource source = FindSource(sourceObject, sourceType);
        source.Stop();
        source.clip = clip;
        source.Play();
    }
    #endregion

    #region Private Methods
    private float folleyTimer=0;
    private void PlayeRandomFolleySounds()
    {
        if (playFolleys)
        {
            float randomTimer = Random.Range(30, 160);
            if (folleyTimer <= randomTimer)
            {
                folleyTimer += Time.deltaTime;
            }
            else
            {
                AudioSource source =  LookForAvailableSource(SourceToUse.Environment);
                source.PlayOneShot(folleyClips[Random.Range(0, folleyClips.Length)]);
                folleyTimer = 0;
            }
        }
    }   
    #endregion
}
