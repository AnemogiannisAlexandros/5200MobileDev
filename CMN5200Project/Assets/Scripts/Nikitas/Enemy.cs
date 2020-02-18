using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{ 
    [SerializeField] private GameObject flame;
 
     private float Firerate;
     private float Nextfire;

     public Healthbar healthbar;

     public int maxHealth = 100;
     public int currentHealth;

    Rigidbody2D rb;

     
     void Start()
     {
        Firerate = 1f; 
        Nextfire = Time.time;
        currentHealth = maxHealth;
        healthbar.MaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
     }

     void Update()
     {
        FireTime();
     }

     void OnCollisionEnter2D(Collision2D col)
     {
         if (col.gameObject.tag == ("FallenTree"))
         {
             takeDamage(20);
             Debug.Log("dmgg");
         }
     }


    void FireTime()
    {
        if (Time.time > Nextfire)
        {
            Instantiate(flame, transform.position, Quaternion.identity);
            Nextfire = Time.time + Firerate;
        }
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth((currentHealth));

    }
}
