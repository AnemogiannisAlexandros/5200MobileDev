using System.Collections;
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
            Destroy(this);
        }
        SceneManager.sceneLoaded += OnNewSceneLoaded;
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnNewSceneLoaded(Scene current, LoadSceneMode mode) 
    {
        StartCoroutine(BeginSceneFadeIn());
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
