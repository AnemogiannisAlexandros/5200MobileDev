using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jastas {

    public class FallenTrees : MonoBehaviour {

        private Rigidbody2D fallenObject;            // Change RigidBody values
        private BoxCollider2D collider;              // Change Collider values
        [SerializeField] private float timer = 2f;   // Set waiting time 

        // Start is called before the first frame update
        private void Start() {
            fallenObject = GetComponent<Rigidbody2D>();
            fallenObject.bodyType = RigidbodyType2D.Kinematic;
            collider = GetComponent<BoxCollider2D>();
        }

        // if player walks over gameObject start Coroutine
        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("Player")) {
                StartCoroutine(WaitSeconds(timer));
            }

            if (other.gameObject.CompareTag("Player") && fallenObject.velocity.magnitude > 4f) {
                GameManager.Instance.Player.Damage();
            }
        }

        // when player triggers the gameObject change its physics values
        private void OnTriggerEnter2D(Collider2D other) {

            if (other.gameObject.CompareTag("Player")) {
                fallenObject.bodyType = RigidbodyType2D.Dynamic;
                collider.isTrigger = false;
                collider.offset = new Vector2(0, 0);
                collider.size = new Vector2(24, 1);
                fallenObject.mass = 1000;
            }
        }

        // Wait 2 seconds then make RigidBody dynamic
        IEnumerator WaitSeconds(float timer) {
            yield return new WaitForSeconds(timer);
            fallenObject.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}