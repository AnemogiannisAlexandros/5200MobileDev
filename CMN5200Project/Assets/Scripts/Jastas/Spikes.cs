using UnityEngine;



    public class Spikes : MonoBehaviour {

        // Player damage when collides with this gameObject
        void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision");
        if (other.gameObject.CompareTag("Player")) 
        {
        Debug.Log("CollisionIn");
            FindObjectOfType<AnimationHandler>().SetPlayerDead(1);

            PlayerManager.Instance.Damage();
        }
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("CollisionIn");
            FindObjectOfType<AnimationHandler>().SetPlayerDead(1);

            PlayerManager.Instance.Damage();
        }
    }
}
