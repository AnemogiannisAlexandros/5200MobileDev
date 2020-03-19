using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosInteractor : IInteractor
{

    [SerializeField] private LayerMask m_Interactable;
    [SerializeField] private float raycastDistance;
    private Collider2D raycastHit;
    [SerializeField] private BoxCollider2D interactionCollider;
    bool foundObject;
    Player player;
    public float shootForce = 10;

    private void Awake()
    {
        interactionCollider = GetComponent<BoxCollider2D>();
        player = GetComponentInParent<Player>();
        allowFlip = true;
        allowJump = true;
    }
    public override void InteractCondition()
    {
        allowMovement = true;
        if (foundObject && player.IsGrounded())
        {
            Debug.Log("Hittin Collider");
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }
    }

    public override void InteractDown()
    {
        Debug.Log("Hit : " + raycastHit.name);
        GameObject obj = raycastHit.gameObject;
        float xDistance = transform.position.x + obj.transform.lossyScale.x / 2;
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, transform.position, 0.9f);
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        obj.transform.eulerAngles = new Vector3(0, 0, 0);
        obj.GetComponent<Rigidbody2D>().angularVelocity = 0;
    }
    public override void InteractUp()
    {
        GameObject obj = raycastHit.gameObject;
        Debug.Log(obj + "Throw" );
        obj.GetComponent<Rigidbody2D>().AddForce( transform.right * transform.localScale.x * shootForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            raycastHit = collision;
            foundObject = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            raycastHit = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            foundObject = false;
        }
    }
}
