using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class Player : MonoBehaviour
{
    MovementController controller;

    private void Start()
    {
        controller = GetComponent<MovementController>();
    }
}
