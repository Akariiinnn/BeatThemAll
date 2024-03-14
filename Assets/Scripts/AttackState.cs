using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AttackState : BaseState
{
    private readonly IInputController controller;
    private readonly Animator animator;
    private readonly GameObject modelTransform;
    private readonly float damage;

    private readonly Transform shootPosition;

    private readonly PlayerData data;
    //create a list of punches animations strings (hp_straight_right_A2, hp_straight_A, hp_hook_left_tiramis)
    private readonly List<string> punches = new List<string> {"hp_straight_A", "hp_straight_right_A2", "hp_hook_left_Tiramis"};

    public AttackState(IInputController controller, Animator animator, GameObject modelTransform, PlayerData data, Transform shootPosition)
    {
        this.controller = controller;
        this.animator = animator;
        this.modelTransform = modelTransform;
        this.data = data;
        this.shootPosition = shootPosition;
    }

    public override void Update()
    {
        if (controller.IsKicking || controller.IsPunching)
        {
            var rotation = modelTransform.transform.rotation;
            var instance = GameObject.Instantiate(data.Prefab, shootPosition.position, rotation);
            var projectile = instance.GetComponent<Projectile>();
            projectile.SetDirection(rotation * new Vector3(0, 0, 1));
            if (controller.IsKicking)
            {
                animator.Play("hk_rh_right_A2");
                projectile.SetDamage(15);
            }
            else if (controller.IsPunching)
            {
                // cycle through the punches list, when at last, return to the first
                var punch = punches[0];
                if (punch == punches[2])
                {
                    projectile.SetDamage(10);
                }
                else
                {
                    projectile.SetDamage(5);
                }

                punches.RemoveAt(0);
                punches.Add(punch);
                animator.Play(punch);
                Debug.Log(punch);
            }
        }
    }
}