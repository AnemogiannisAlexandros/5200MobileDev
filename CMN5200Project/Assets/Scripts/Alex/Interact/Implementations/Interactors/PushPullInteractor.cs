using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPullInteractor : IInteractor
{
    [SerializeField] private LayerMask m_Interactable;
    [SerializeField] private float raycastDistance;
    private RaycastHit2D raycastHit;

    public override void InteractCondition()
    {
        allowMovement = true;
        raycastHit = Physics2D.Raycast(transform.position,new Vector2(transform.localScale.x, 0), raycastDistance, m_Interactable);
        Debug.DrawLine(transform.position, new Vector2((transform.localScale.x * raycastDistance)+transform.position.x, transform.position.y), Color.green);
        Debug.Log(canInteract);
        if (raycastHit.collider != null)
        {
            if (raycastHit.collider.gameObject != gameObject)
            {
                if (raycastHit.distance <= raycastDistance)
                {
                    canInteract = true;
                }
            }
        }
        else 
        {
            canInteract = false;
        }
    }
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Hit : " + raycastHit.collider.name);
        GameObject obj = raycastHit.collider.gameObject;
        float xDistance = GetComponent<CapsuleCollider2D>().size.x / 2 + obj.transform.localScale.x / 2 + 3f;
        obj.transform.position = transform.position + transform.right * xDistance * transform.localScale.x;
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
