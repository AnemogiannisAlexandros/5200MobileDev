﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField]
    private IInteractor interactor;

    public void Interact()
    {

        if (interactor.CanInteract())
        {
            interactor.Interact();
            GetComponent<PlayerInput>().SetPlayerState(PlayerInput.PlayerState.Interacting);
        }
    }
    private void Update()
    {
        interactor.InteractCondition();
        if (!interactor.CanInteract()) 
        {
            GetComponent<PlayerInput>().SetPlayerState(PlayerInput.PlayerState.Normal);
        }
    }
    public void SetInteractor(IInteractor interactor) 
    {
        this.interactor = interactor;
    }
    public IInteractor GetInteractor() 
    {
        return interactor;
    }
}
