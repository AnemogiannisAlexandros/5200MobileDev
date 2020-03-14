using UnityEngine;

namespace Jastas {
    
    public class Rocks : MonoBehaviour {

        [SerializeField] private Rigidbody2D[] rocks;

        private void Start() {
            for (int i = 0; i < rocks.Length; i++) {
                rocks[i] = GameObject.FindGameObjectsWithTag("Rocks")[i].GetComponent<Rigidbody2D>();
                rocks[i].bodyType = RigidbodyType2D.Kinematic;
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            for (int i = 0; i < rocks.Length; i++) {
                if (other.gameObject.CompareTag("Player")) {
                    rocks[i].bodyType = RigidbodyType2D.Dynamic;
                    rocks[i].mass = 1000;
                    PlayerManager.Instance.Damage();
                    FindObjectOfType<AnimationHandler>().SetPlayerDead(1);
                    Debug.Log("player damage");
                }
            }
        }
    }
}
