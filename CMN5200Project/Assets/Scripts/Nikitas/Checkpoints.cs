using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager.Instance.checkpointPos = transform.GetChild(0).position;
            Debug.Log("dffssfdsfdfdsfdfqfq");
        }
    }
}
