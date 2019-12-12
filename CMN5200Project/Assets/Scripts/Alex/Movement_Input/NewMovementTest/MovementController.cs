using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MovementController : MonoBehaviour
{
    BoxCollider2D _Collider;
    const float skinWidth = .015f;
    RaycastOrigins raycastOrigins;
    public int horizontalRaycount = 4;
    public int verticalRaycount = 4;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    public void Start()
    {
        _Collider = GetComponent<BoxCollider2D>();
    }
    public void Update()
    {
        UpdateRaycastOrigins();
        CalculateRaySpacing();

        for (int i = 0; i < verticalRaySpacing; i++) 
        {
            Debug.DrawRay(raycastOrigins.bottomLeft + Vector2.right * verticalRaySpacing * i, Vector2.right * 2, Color.red);
        }
        for (int i = 0; i < horizontalRaySpacing; i++) 
        {
            Debug.DrawRay(raycastOrigins.bottomLeft + Vector2.up * horizontalRaySpacing * i, Vector2.up * 2, Color.green);
        }
    }
    void UpdateRaycastOrigins() 
    {
        Bounds bounds = _Collider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }
    private void CalculateRaySpacing()
    {
        Bounds bounds = _Collider.bounds;
        bounds.Expand(skinWidth * -2);
        horizontalRaycount = Mathf.Clamp(horizontalRaycount, 2, int.MaxValue);
        verticalRaycount = Mathf.Clamp(verticalRaycount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRaycount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRaycount - 1);
    }
    struct RaycastOrigins 
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
}
