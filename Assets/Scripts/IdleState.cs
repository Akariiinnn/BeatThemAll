using UnityEngine;

public class IdleState : BaseState
{
    public override void Begin()
    {
        Debug.Log("Idle");
    }
}