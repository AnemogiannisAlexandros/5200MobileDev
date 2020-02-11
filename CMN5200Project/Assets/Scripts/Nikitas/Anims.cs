using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anims : MonoBehaviour
{
    Animator animator;
    private GameObject player;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Spikes")
        {
            
           
                animator.SetTrigger("deathBySpike");

                Debug.Log("dmg");
          
        }

    }
}
