using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;

    public IInputController controller;

    public CharacterController2D characterController;

    public float moveSpeed = 40f;
    private bool jump = false;
    float horizontalMovement=0f;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (controller.JumpKeyPressed()) 
        {
            Jump();
        }
        if (controller.LeftKeyPressed())
        {
            Left();
        }
        else if (controller.RightKeyPressed())
        {
            Right();
        }
        else 
        {
            horizontalMovement = 0;
        }
        if (controller.InteractKeyPressed()) 
        {
            Interact();
        }
    }
    public void FixedUpdate()
    {
        Debug.Log("Fixed Running");
        Debug.Log(horizontalMovement);
        characterController.Move(horizontalMovement * moveSpeed * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    public void Jump() 
    {
        //rb.AddForce(Vector2.up*5, ForceMode2D.Impulse);
        jump = true;
        Debug.Log("Jumping");
    }
    public void Left() 
    {
        horizontalMovement = -1;
        //rb.AddForce(Vector2.right * (-3), ForceMode2D.Force);
       // Debug.Log("Left " + horizontalMovement);
    }
    public void Right() 
    {
        horizontalMovement = 1;
        //rb.AddForce(Vector2.right * 3, ForceMode2D.Force);
       // Debug.Log("Right " + horizontalMovement);
    }
    public void Interact() 
    {
        Debug.Log("teracting");
    }
}
