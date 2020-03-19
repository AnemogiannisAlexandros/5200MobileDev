//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//using UnityEngine;
///*
// *  Extends the UnityEngine.UI.Button class so that we can override
// *  some of the base functions to allow for greater controll
//*/
//public class JumpButtonScript : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
//{
//    private PlayerInput playerInput;
//    void Awake()
//    {
//        playerInput = FindObjectOfType<PlayerInput>();
//    }
//    bool isPressed = false;
//    bool isReleased = false;
//    private void Update()
//    {
//        if (isPressed)
//        {
//            playerInput.controller.jumpButtonDown = true;
//            playerInput.controller.jumpButtonUp = false;
//        }
//        else if (isReleased)
//        {
//            playerInput.controller.jumpButtonDown = false;
//            playerInput.controller.jumpButtonUp = true;
//        }
//        else 
//        {
//            playerInput.controller.jumpButtonDown = false;
//            playerInput.controller.jumpButtonUp = false;
//        }
//    }

//    public void OnPointerDown(PointerEventData eventData)
//    {

//        isPressed = true;
//        isReleased = false;
//    }
//    public void OnPointerUp(PointerEventData eventData)
//    {
//        isPressed = false;
//        isReleased = true;
//    }
//}
