using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private readonly IInputController controller;
    private readonly Animator animator;
    private readonly float damage;
    //create a list of punches animations strings (hp_straight_right_A2, hp_straight_A, hp_hook_left_tiramis)
    private readonly List<string> punches = new List<string> {"hp_straight_A", "hp_straight_right_A2", "hp_hook_left_Tiramis"};

    public AttackState(IInputController controller, Animator animator)
    {
        this.controller = controller;
        this.animator = animator;
    }

    public override void Update()
    {
        if (controller.IsKicking)
        {
            animator.Play("hk_rh_right_A2");
        } else if (controller.IsPunching)
        {
            // cycle through the punches list, when at last, return to the first
            var punch = punches[0];
            punches.RemoveAt(0);
            punches.Add(punch);
            animator.Play(punch);
            Debug.Log(punch);
        }
    }
}