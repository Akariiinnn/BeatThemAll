using UnityEngine;

public class AttackState : BaseState
{
    private readonly GameObject target;
    private readonly IInputController controller;
    private readonly PlayerData data;
    private readonly Animator animator;
    private readonly GameObject modelTransform;
    private readonly float baseSpeed;

    public AttackState(GameObject target, IInputController controller, PlayerData data, Animator animator)
    {
        this.controller = controller;
        this.target = target;
        this.data = data;
        this.animator = animator;
    }

    public override void Update()
    {
        if (controller.IsKicking)
        {
            animator.Play("hk_rh_right_A2");
        } else if (controller.IsPunching)
        {
            animator.Play("hp_straight_right_A2");
        }
    }
}