using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class Player : MonoBehaviour
{
    public float jumpHeight = 4;   //highest point of jump in Units
    public float timeToJumpApex = .4f; //Amount of time to reach the Highest point

    float moveSpeed = 6;
    public float accelerationTimeAir = .2f;
    public float accelerationTimeGround = .1f;
    float gravity;
    Vector3 velocity;
    float jumpVelocity;
    float velocityXsmoothing;

    MovementController controller;

    private void Start()
    {
        controller = GetComponent<MovementController>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        Debug.Log(gravity + " " + jumpVelocity);
    }
    private void Update()
    {
        if (controller.collisionsInfo.above || controller.collisionsInfo.below) 
        {
            velocity.y = 0;
        }
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space) && controller.collisionsInfo.below) 
        {
            velocity.y = jumpVelocity;
        }
        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXsmoothing,(controller.collisionsInfo.below)?accelerationTimeGround:accelerationTimeAir);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
