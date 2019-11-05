﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : Button
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
        base.OnPointerDown(eventData);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        base.OnPointerUp(eventData);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        isPressed = false;
        base.OnPointerExit(eventData);
    }
}
