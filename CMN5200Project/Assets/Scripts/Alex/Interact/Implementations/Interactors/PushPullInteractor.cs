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
        //raycastHit = Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x,0), raycastDistance, m_Interactable);
        //Debug.DrawRay(transform.position, new Vector2(transform.localScale.x, 0) * raycastDistance, Color.green);
        raycastHit = Physics2D.BoxCast(transform.position + new Vector3(transform.localScale.x*1.5f,-.2f,0), transform.localScale * raycastDistance, 0, new Vector2(transform.localScale.x, transform.position.y),raycastDistance,m_Interactable);
        Debug.Log(canInteract);

        if (raycastHit.collider != null)
        {
            if (raycastHit.collider.gameObject != gameObject)
            {
                if (raycastHit.distance <= raycastDistance)
                {
                    Debug.Log("Hittin Collider");
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
        float xDistance = GetComponent<CapsuleCollider2D>().size.x / 2 + obj.transform.lossyScale.x / 2;
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, (transform.position + transform.right * xDistance / 2 * transform.localScale.x * 1.3f), 0.1f);
        // = transform.position + transform.right * xDistance/2 * transform.localScale.x *1.3f;
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + new Vector3(transform.localScale.x*1.5f,-.2f, 0), transform.localScale * raycastDistance);
    }
}
