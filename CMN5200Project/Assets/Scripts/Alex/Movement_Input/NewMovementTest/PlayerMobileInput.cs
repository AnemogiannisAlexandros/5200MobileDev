using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileInput : MonoBehaviour
{
    Player player;
    AnimationHandler animator;
    public IInputController controller;
    InteractionHandler interactionHandler;
    private PlayerState curentState;
    private bool facingRight = true;
    Controller2D playerController;
    public Transform flipTransform;
    Vector2 directionalInput;


    public void SetPlayerState(PlayerState state)
    {
        curentState = state;
    }

    void Start()
    {
        player = GetComponent<Player>();
        animator = FindObjectOfType<AnimationHandler>();
        curentState = PlayerState.Normal;
        interactionHandler = FindObjectOfType<InteractionHandler>();
        playerController = GetComponent<Controller2D>();
    }

    void Update()
    {
        if (!PlayerManager.Instance.IsDead)
        {
            if (PlayerManager.Instance.AllowInput)
            {

                directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                if (directionalInput.x > 0 && !facingRight && curentState != PlayerState.Interacting)
                {
                    Flip();
                }
                else if (directionalInput.x < 0 && facingRight && curentState != PlayerState.Interacting)
                {
                    Flip();
                }
                player.SetDirectionalInput(directionalInput);
                animator.UpdateMovement(directionalInput.x != 0 ? true : false);
                animator.SetGrounded(player.IsGrounded());

                if (controller.JumpKeyPressed() && curentState != PlayerState.Interacting)
                {
                    player.OnJumpInputDown();
                    animator.TriggerJump();
                }
                if (controller.JumpKeyReleased() && curentState != PlayerState.Interacting)
                {
                    player.OnJumpInputUp();
                    animator.ResetJump();
                }
                animator.SetGrounded(player.IsGrounded());
                animator.SetFalling(player.isFalling() ? true : false);
                if (controller.InteractKeyPressed())
                {
                    interactionHandler.Interact();
                }
                else
                {
                    curentState = PlayerState.Normal;
                }
            }
            else
            {
                animator.GetComponent<Animator>().Play("Idle");
            }
        }

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = flipTransform.localScale;
        theScale.x *= -1;
        flipTransform.localScale = theScale;
    }
}
