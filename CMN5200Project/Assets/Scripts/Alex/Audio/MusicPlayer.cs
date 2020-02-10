using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioManager manager;
    private AudioClip[] musicClips;
    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        manager = AudioManager.Instance;
        musicClips = manager.GetMusicClips();
        manager.PlayeOnSource("Music", SourceToUse.Background, musicClips[Random.Range(0, musicClips.Length)]);
    }
    private void Update()
    {
        if (!source.isPlaying)
        {
            source.PlayOneShot(musicClips[Random.Range(0, musicClips.Length)]);
        }
    }
}
