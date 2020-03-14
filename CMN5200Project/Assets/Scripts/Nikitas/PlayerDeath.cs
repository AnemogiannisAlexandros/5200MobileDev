using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour
{
    public Animation anim;
     void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Boss"))
        {
         
            PlayerManager.Instance.Damage();
            anim.Play("DeathFromSpikes");

        }
    }

}
