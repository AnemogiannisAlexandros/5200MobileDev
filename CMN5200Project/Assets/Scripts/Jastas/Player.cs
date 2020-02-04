using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jastas
{


    public class Player: MonoBehaviour, IDamageable {
    
        // Variables
        Rigidbody2D playerRigidbody;
        [SerializeField] float moveX;
        [SerializeField] float playerSpeed = 2.0f;
        [SerializeField] float jumpForce = 5.0f;
        [SerializeField] bool resetJump;
        [SerializeField] bool isGrounded;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] bool isDead;
    
        // Variable for animation
        PlayerAnimation playerAnim;
        // Variable for flip player
        SpriteRenderer flipPlayer;

        // Start is called before the first frame update
        void Start() {
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerAnim = GetComponent<PlayerAnimation>();
            flipPlayer = GetComponentInChildren<SpriteRenderer>();
            isDead = false;
            Health = 1;
        }

        // Update is called once per frame
        void FixedUpdate() {
            MovePlayer();
        }

        // Player controller for movement
        void MovePlayer() {
            moveX = Input.GetAxisRaw("Horizontal");
            isGrounded = IsGrounded();
            Flip(moveX);
            // Make player to jump
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
                playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                StartCoroutine(ResetJump());
                playerAnim.Jump(true);
            }
            playerRigidbody.velocity = new Vector2(moveX * playerSpeed , playerRigidbody.velocity.y);
            playerAnim.Move(moveX);
        } 
    
        // Check if the player is grounded
        bool IsGrounded() {
            // Raycast for jump
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, groundLayer.value);
            Debug.DrawRay(transform.position, Vector2.down * 2f, Color.red);
            if (hit.collider != null) {
                if (resetJump == false) {
                    playerAnim.Jump(false);
                    Debug.Log("Hit " + hit.collider.name);
                    return true;   
                }
            }
            return false;
        }
    
        // Flip player
        void Flip(float moveX) {
            if (moveX > 0) {
                flipPlayer.flipX = false;
            }
            else if (moveX < 0) {
                flipPlayer.flipX = true;
            }   
        }
    
        // Set resetJump to false after 0.1f seconds
        IEnumerator ResetJump() {
            resetJump = true;
            yield return new WaitForSeconds(0.1f);
            resetJump = false;
        }
    
        public int Health { get; set; }

        public void Damage() {
            Health--;
            if (Health < 1) {
                isDead = true;
                Debug.Log("Player is dead");
            }
        }
    }
}