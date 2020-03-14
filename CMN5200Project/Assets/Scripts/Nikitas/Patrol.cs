using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float dis;
    private bool Rside = true;
    public Transform groundDetection;
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
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            Rside = true;
        }
   
     }

}
