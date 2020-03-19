//Gives all our Interact Methods a type and allows us to
//interact with specific objects depending on our interactor
using System;
using UnityEngine;

public abstract class IInteractor : MonoBehaviour
{
    protected bool canInteract;
    protected bool allowMovement;
    protected bool allowFlip;
    protected bool allowJump;
    public bool CanFlip() 
    {
        return allowFlip;
    }
    public bool CanJump() 
    {
        return allowJump;
    }
    public virtual bool CanInteract() 
    {
        return canInteract;
    }
    public virtual void InteractCondition() 
    {
       
    }
    public virtual void InteractDown()
    {

    }
    public virtual void InteractUp()
    {

    }
}
