using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Interaction : MonoBehaviour
{
    public GameObject objToChangeLayer;
    public GameObject colliderToSetActive;


   private void OnTriggerEnter2D(Collider2D collision)
    {
        colliderToSetActive.GetComponent<BoxCollider2D>().enabled = true;
        //objToChangeLayer.layer = 10;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
    }
}
