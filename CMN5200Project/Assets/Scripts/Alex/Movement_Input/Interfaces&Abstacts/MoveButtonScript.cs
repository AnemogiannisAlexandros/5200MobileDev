﻿//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//using UnityEngine;

//public class MoveButtonScript : MonoBehaviour ,IPointerDownHandler,IPointerUpHandler,IPointerExitHandler
//{
//    private PlayerInput playerInput;
//    void Awake()
//    {
//        playerInput = FindObjectOfType<PlayerInput>();
//    }
//    bool isPressed = false;

//    private void Update()
//    {
//        if (isPressed)
//        {
//            playerInput.controller.leftButton = true;
//        }
//        else
//        {
//            playerInput.controller.leftButton = false;
//        }       
//    }
//    public void OnPointerDown(PointerEventData eventData)
//    {
//        isPressed = true;
//    }
//    public void OnPointerUp(PointerEventData eventData)
//    {
//        isPressed = false;
//    }
//    public void OnPointerExit(PointerEventData eventData)
//    {
//        isPressed = false;
//    }
//}
