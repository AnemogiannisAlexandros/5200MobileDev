using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    private AudioClip hoverClip,ClickClip;

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<AudioSource>().PlayOneShot(ClickClip); 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<AudioSource>().PlayOneShot(hoverClip);
    }
}
