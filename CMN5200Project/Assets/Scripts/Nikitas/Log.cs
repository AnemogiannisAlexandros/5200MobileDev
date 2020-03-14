using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    private Rigidbody2D fallenObject;
    public Transform spawn;
    private BoxCollider2D collider;
    [SerializeField] 
    private float timer = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        fallenObject = GetComponent<Rigidbody2D>();
        fallenObject.bodyType = RigidbodyType2D.Kinematic;
        collider = GetComponent<BoxCollider2D>();
        StartCoroutine(WaitSeconds(timer));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Boss"))
        {
            Respawn();          
        }
    }
    public void Respawn()
    {
        this.transform.position = spawn.position;
        fallenObject.bodyType = RigidbodyType2D.Kinematic;
        StartCoroutine(WaitSeconds(timer));
        rb.velocity =  Vector3.zero;
        rb.angularVelocity = 0;
    }

    IEnumerator WaitSeconds(float timer)
    {
        yield return new WaitForSeconds(timer);
        fallenObject.bodyType = RigidbodyType2D.Dynamic;
    }
}
