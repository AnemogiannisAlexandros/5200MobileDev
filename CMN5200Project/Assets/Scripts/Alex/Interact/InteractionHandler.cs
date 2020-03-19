using System.Collections;
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
            interactor.InteractDown();
            GetComponentInParent<PlayerInput>().SetPlayerState(PlayerState.Interacting);
        }
    }
    public void InteractUp() 
    {
        interactor.InteractUp();
        GetComponentInParent<PlayerInput>().SetPlayerState(PlayerState.Normal);
    }
    private void Update()
    {
        if (PlayerManager.Instance.AllowInput) 
        {
            interactor.InteractCondition();
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
