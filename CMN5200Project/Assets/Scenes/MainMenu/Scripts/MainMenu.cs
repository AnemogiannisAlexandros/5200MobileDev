using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
       StartCoroutine(SceneTransitonManager.Instance.BeginSceneFadeOut());
    }

    public void Quit()
    {
        Application.Quit();
    }
}
