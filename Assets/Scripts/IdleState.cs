using UnityEngine;

public class IdleState : BaseState
{
    private readonly IInputController controller;
    private readonly Animator animator;
    
    public IdleState(IInputController controller, Animator animator)
    {
        this.controller = controller;
        this.animator = animator;
    }
    
    public override void Begin()
    {
        Debug.Log("Idle");
    }

    public override void Update()
    {
        controller.IsRunning = false;
        animator.SetBool("movetorun", false);
    }
}