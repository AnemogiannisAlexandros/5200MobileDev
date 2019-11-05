using UnityEngine;

public abstract class IInputController : ScriptableObject
{
    public abstract bool LeftKeyPressed();
    public abstract bool RightKeyPressed();
    public abstract bool JumpKeyPressed();
    public abstract bool InteractKeyPressed();
}
