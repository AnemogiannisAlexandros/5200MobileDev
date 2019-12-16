using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;
    AnimationHandler animator;
    public IInputController controller;
    InteractionHandler interactionHandler;
    private PlayerState curentState;
    private bool facingRight = true;
    Controller2D playerController;

    public enum PlayerState
    {
        Normal,
        Interacting,
    }

    public void SetPlayerState(PlayerState state)
    {
        curentState = state;
    }

    void Start () {
		player = GetComponent<Player> ();
        animator = GetComponent<AnimationHandler>();
        curentState = PlayerState.Normal;
        interactionHandler = GetComponent<InteractionHandler>();
        playerController = GetComponent<Controller2D>();
    }

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		player.SetDirectionalInput (directionalInput);
        animator.UpdateMovement(directionalInput.x != 0 ? true : false);
        animator.SetGrounded(player.IsGrounded());
        if (directionalInput.x > 0 && !facingRight && curentState !=PlayerState.Interacting)
        {
            Flip();
        }
        else if(directionalInput.x<0 && facingRight && curentState != PlayerState.Interacting)
        {
            Flip();
        }
		if (controller.JumpKeyPressed() && curentState != PlayerState.Interacting) {
			player.OnJumpInputDown ();
            animator.TriggerJump();
		}
		if (controller.JumpKeyReleased() && curentState != PlayerState.Interacting) {
			player.OnJumpInputUp ();
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
  
        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            facingRight = !facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
}
