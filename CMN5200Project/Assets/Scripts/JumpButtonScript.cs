using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpButtonScript : Button
{
    bool isPressed = false;
    private void Update()
    {
        if (isPressed)
        {
            onClick.Invoke();
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {

        isPressed = true;
        isPressed = false;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        isPressed = false;
        base.OnPointerClick(eventData);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        base.OnPointerUp(eventData);
    }
}
