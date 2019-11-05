using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;

    public IInputController controller;

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
        else if(controller.RightKeyPressed())
        {
            Right();
        }
        if (controller.InteractKeyPressed()) 
        {
            Interact();
        }
    }
    public void Jump() 
    {
        rb.AddForce(Vector2.up*5, ForceMode2D.Impulse);
        Debug.Log("Jumping");
    }
    public void Left() 
    {
        rb.AddForce(Vector2.right * (-3), ForceMode2D.Force);
        Debug.Log("Left");
    }
    public void Right() 
    {
        rb.AddForce(Vector2.right * 3, ForceMode2D.Force);
        Debug.Log("Right");
    }
    public void Interact() 
    {
        Debug.Log("teracting");
    }
}
