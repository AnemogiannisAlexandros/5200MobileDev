using UnityEngine;

namespace Jastas
{
    public class Spikes : MonoBehaviour
    {

        // Player damage when collides with this gameObject
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerManager.Instance.Damage();
                FindObjectOfType<AnimationHandler>().SetPlayerDead(0);
            }
        }
    }
}

