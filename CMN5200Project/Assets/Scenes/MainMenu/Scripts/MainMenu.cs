using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneTransitonManager.Instance.StopAllCoroutines();
       StartCoroutine(SceneTransitonManager.Instance.BeginSceneFadeOut());
    }

    public void Quit()
    {
        Application.Quit();
    }
}
