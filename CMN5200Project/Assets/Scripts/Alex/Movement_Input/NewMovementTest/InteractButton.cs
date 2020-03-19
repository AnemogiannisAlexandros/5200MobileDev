//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;


//public class InteractButton : MonoBehaviour , IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
//{
//    private PlayerInput playerInput;
//    bool isPressed = false;

//    void Awake()
//    {
//        playerInput = FindObjectOfType<PlayerInput>();
//    }
//    public void LateUpdate()
//    {
//        playerInput.controller.interactionButtonUp = false;
//    }
//    public void OnPointerDown(PointerEventData eventData)
//    {
//        playerInput.controller.interactionButtonDown = true;
//        playerInput.controller.interactionButtonUp = false;
//    }
//    public void OnPointerUp(PointerEventData eventData)
//    {
//        playerInput.controller.interactionButtonDown = false;
//        playerInput.controller.interactionButtonUp = true;

//    }
//    public void OnPointerExit(PointerEventData eventData)
//    {
//        playerInput.controller.interactionButtonDown = false;
//        playerInput.controller.interactionButtonUp = true;
//    }

//}
