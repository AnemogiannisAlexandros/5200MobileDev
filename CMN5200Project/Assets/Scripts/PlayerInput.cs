using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D _rb;

    public IInputController controller;

    private CharacterController2D _CharacterController;

    public float moveSpeed = 40f;
    private bool jump = false;
    float horizontalMovement=0f;

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _CharacterController = GetComponent<CharacterController2D>();
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
        _CharacterController.Move(horizontalMovement * moveSpeed * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    public void Jump() 
    {
        //_rb.AddForce(Vector2.up*5, ForceMode2D.Impulse);
        jump = true;
        Debug.Log("Jumping");
    }
    public void Left() 
    {
        horizontalMovement = -1;
        //_rb.AddForce(Vector2.right * (-3), ForceMode2D.Force);
       // Debug.Log("Left " + horizontalMovement);
    }
    public void Right() 
    {
        horizontalMovement = 1;
        //_rb.AddForce(Vector2.right * 3, ForceMode2D.Force);
       // Debug.Log("Right " + horizontalMovement);
    }
    public void Interact() 
    {
        Debug.Log("teracting");
    }
}
