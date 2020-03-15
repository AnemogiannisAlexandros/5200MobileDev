using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForAnimToFinish : MonoBehaviour
{

   public Camera playerCamera, cinematicCamera;
    public float seconds;
    private void Start()
    {
        StartCoroutine(WaitForSeconds(seconds));
    }
    private IEnumerator WaitForSeconds(float seconds)
    {
        PlayerManager.Instance.AllowInput = false;
        playerCamera.gameObject.SetActive(false);
        cinematicCamera.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        playerCamera.gameObject.SetActive(true);
        cinematicCamera.gameObject.SetActive(false);
        PlayerManager.Instance.AllowInput = true;

    }
}
