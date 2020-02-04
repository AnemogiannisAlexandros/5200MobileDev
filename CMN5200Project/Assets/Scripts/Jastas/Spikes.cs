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
                GameManager.Instance.Player.Damage();
            }
        }
    }
}

