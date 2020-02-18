using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Flame : MonoBehaviour
{
    private float speed = 20f; //to speed tou flame

    private Rigidbody2D rb; 

    private Player target; //to target toy flame
    private Vector2 Dir;  // to direction tou flame

    void Start()
    {
        FlameAttack();
    }


    public void FlameAttack()
    {

        target = GameObject.FindObjectOfType<Player>(); //h sfaira psaxnei ton stoxo ths dld ton paixth
        rb = GetComponent<Rigidbody2D>();
        Dir = (target.transform.position - transform.position).normalized * speed; //metafeerei to flame apo to arxiko position sto potision toy target
        rb.velocity = new Vector2(Dir.x, Dir.y); //kinhsh tou flame
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
            Debug.Log("hit'em all");
        }
    }
}
