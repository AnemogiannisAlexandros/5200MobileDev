using UnityEngine;
namespace Jastas
{
    public class PlayerAnimation : MonoBehaviour
    {

        Animator playerAnimator;

        // Start is called before the first frame update
        void Start()
        {
            playerAnimator = GetComponentInChildren<Animator>();
        }

        public void Move(float move)
        {
            playerAnimator.SetFloat("Move", Mathf.Abs(move));
        }

        public void Jump(bool jumping)
        {
            playerAnimator.SetBool("Jumping", jumping);
        }
    }
}

