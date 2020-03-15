using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    GameObject Boss;
    public Healthbar healthbar;

    public int maxHealth = 100;
    public int currentHealth;

    public float speed;
    public float dis;
    private bool Rside = true;
    public Transform groundDetection;  

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.MaxHealth(maxHealth);   
    }

     void Update()
     {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, dis);
        if (groundinfo.collider == false)
        {
            if (Rside == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                Rside = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                Rside = true;
            }
        }
     }

     void OnTriggerEnter2D(Collider2D col)
     {
        if (col.gameObject.CompareTag("Player")) 
        {
            PlayerManager.Instance.Damage();
            FindObjectOfType<AnimationHandler>().SetPlayerDead(1);
        }
         if (col.gameObject.tag == ("FallenTree"))
         {
            takeDamage(20);
            Debug.Log("dmgg");

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }   
         }      
     }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth((currentHealth));
    }
}
