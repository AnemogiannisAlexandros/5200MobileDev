//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;


//public class MoveRightButton : MonoBehaviour , IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
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
//            playerInput.controller.rightButton = true;
//        }
//        else
//        {
//            playerInput.controller.rightButton = false;
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
