﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SceneTransitonManager : MonoBehaviour
{
    private static SceneTransitonManager m_instance;
    public static SceneTransitonManager Instance { get { return m_instance; }}

    public Image blackPanel;
    public AudioMixer audioMixer;

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
        SceneManager.sceneLoaded += OnNewSceneLoaded;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Debug.Log("Working");
            StopAllCoroutines();
            StartCoroutine(BeginSceneFadeOut());
        }
    }
    private void OnNewSceneLoaded(Scene current, LoadSceneMode mode) 
    {
        StartCoroutine(BeginSceneFadeIn());
    }

    public IEnumerator SimpleCrossFade() 
    {
        while (blackPanel.color.a < 1)
        {
            Debug.Log("FirstPart");
            blackPanel.color += new Color(0, 0, 0, 0.006f);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1);
        while (blackPanel.color.a > 0)
        {
            Debug.Log("SecondPart");
            blackPanel.color -= new Color(0, 0, 0, 0.006f);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator BeginSceneFadeIn()
    {
        while (blackPanel.color.a > 0)
        {
            Debug.Log("Running");
            blackPanel.color -= new Color(0, 0, 0, 0.005f);
            float currentVolume;
            audioMixer.GetFloat("MasterAudio", out currentVolume);
            if (currentVolume < 0) 
            {
                audioMixer.SetFloat("MasterAudio", currentVolume + 0.2f);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator BeginSceneFadeOut(int sceneIndex) 
    {
        while (blackPanel.color.a < 1)
        {
            Debug.Log("Running");

            blackPanel.color += new Color(0, 0, 0, 0.005f);
            float currentVolume;
            audioMixer.GetFloat("MasterAudio", out currentVolume);
            audioMixer.SetFloat("MasterAudio", currentVolume - 0.2f);
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(sceneIndex);
    }
    public IEnumerator BeginSceneFadeOut()
    {
        while (blackPanel.color.a < 1)
        {
            Debug.Log("Running");

            blackPanel.color += new Color(0, 0, 0, 0.005f);
            float currentVolume;
            audioMixer.GetFloat("MasterAudio", out currentVolume);
            audioMixer.SetFloat("MasterAudio", currentVolume - 0.2f);
            yield return new WaitForEndOfFrame();
        }
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
