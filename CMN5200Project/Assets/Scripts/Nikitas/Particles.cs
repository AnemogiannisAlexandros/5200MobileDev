using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
   
    public ParticleSystem BloodSprayEffect;
    private Vector3 position;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("FallenTree"))
        {
            Blood();
        }
    }
    void Blood()
    {
        Instantiate(BloodSprayEffect);
        BloodSprayEffect.Play();
    }
}
