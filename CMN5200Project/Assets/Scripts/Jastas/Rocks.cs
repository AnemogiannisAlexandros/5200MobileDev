using UnityEngine;

namespace Jastas {
    
    public class Rocks : MonoBehaviour {

        [SerializeField] private Rigidbody2D[] rocks;
        [SerializeField] private CircleCollider2D[] collider;
        [SerializeField] private AudioSource[] audioRocks;
        private BoxCollider2D player;
        private PolygonCollider2D ground;

        private void Start() {

            player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
            ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<PolygonCollider2D>();
            
            for (int i = 0; i < rocks.Length; i++) {
                rocks[i] = GameObject.FindGameObjectsWithTag("Rocks")[i].GetComponent<Rigidbody2D>();
                rocks[i].bodyType = RigidbodyType2D.Kinematic;
            }

            for (int i = 0; i < audioRocks.Length; i++) {
                audioRocks[i] = GameObject.FindGameObjectsWithTag("Rocks")[i].GetComponent<AudioSource>();
                audioRocks[i].Stop();
            }
        }

        void Update() {
            RocksDamage();
        }

        // Activates Rigidbodies from kinematic to dynamic
        private void OnTriggerEnter2D(Collider2D other) {
            for (int i = 0; i < rocks.Length; i++) {
                if (other.gameObject.CompareTag("Player")) {
                    rocks[i].bodyType = RigidbodyType2D.Dynamic;
                    rocks[i].mass = 1000;
                }
            }
        }

        // When any object collides with player collider
        // Set damage to the player 
        void RocksDamage() {
            for (int i = 0; i < rocks.Length; i++) {
                foreach (CircleCollider2D rock in collider) {
                    if (rock.IsTouching(player) && rocks[i].velocity.magnitude > 2f) {
                        GameManager.Instance.Player.Damage();
                    }
                }
            }
        }
    }
}