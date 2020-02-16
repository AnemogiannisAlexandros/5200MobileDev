using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject flame;

    private float Firerate;
    private float Nextfire;


    void Start()
    {
        Firerate = 1f;
        Nextfire = Time.time;
    }


    void Update()
    {
        FireTime();
    }

    // void OnTriggerEnter2D(Collider2D col)
    // {
    //   if (col.gameObject.tag.Equals("Box"))
    //   {
    // FireTime();
     //}
      // }

void FireTime()
    {
        if (Time.time > Nextfire)
        {
            Instantiate(flame, transform.position, Quaternion.identity);
            Nextfire = Time.time + Firerate;
        }
    }
}
