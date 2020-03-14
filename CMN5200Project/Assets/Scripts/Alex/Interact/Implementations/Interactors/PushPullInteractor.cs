using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPullInteractor : IInteractor
{
    [SerializeField] private LayerMask m_Interactable;
    [SerializeField] private float raycastDistance;
    private Collider2D raycastHit;
    [SerializeField] private BoxCollider2D interactionCollider;
    bool foundObject;
    Player player;

    private void Awake()
    {
        interactionCollider = GetComponent<BoxCollider2D>();
        player = GetComponentInParent<Player>();
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
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Hit : " + raycastHit.name);
        GameObject obj = raycastHit.gameObject;
        float xDistance = GetComponent<BoxCollider2D>().size.x / 2 + obj.transform.lossyScale.x/2;
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, (transform.position + transform.right * xDistance * transform.localScale.x/2), 0.9f);
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        obj.transform.eulerAngles = new Vector3(0,0,0);
        obj.GetComponent<Rigidbody2D>().angularVelocity = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interactable")) 
        {
            Debug.Log(collision.name);
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
            Debug.Log(collision.name);
            foundObject = false;
        }
    }
}
