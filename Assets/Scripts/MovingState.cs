using UnityEngine;

public class MovingState : BaseState
{
    private readonly GameObject target;
    private readonly IInputController controller;
    private readonly PlayerData data;
    private readonly Animator animator;
    private readonly GameObject modelTransform;
    private readonly float baseSpeed;

    public MovingState(GameObject target, IInputController controller, PlayerData data, Animator animator,
        GameObject modelTransform)
    {
        this.controller = controller;
        this.target = target;
        this.data = data;
        this.animator = animator;
        this.modelTransform = modelTransform;
        baseSpeed = data.Speed;
    }
    
    public override void Begin()
    {
        
    }

    public override void Update()
    {
        animator.SetBool("idletomove", true);
        if (controller.IsRunning)
        {
            data.Speed = baseSpeed*2;
            animator.SetBool("movetorun", true);
        } else
        {
            data.Speed = baseSpeed;
            animator.SetBool("movetorun", false);
        }
        RotateCharacter(controller.MoveDirection);
        target.transform.position +=
            target.transform.rotation * controller.MoveDirection * (data.Speed * Time.deltaTime);
    }

    public override void Exit()
    {
        animator.SetBool("idletomove", false);
    }
    
    public void RotateCharacter(Vector3 direction)
    {
        // Ensure that the direction is not zero to avoid division by zero
        if (direction != Vector3.zero)
        {
            // Calculate the target rotation based on the direction
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Smoothly interpolate towards the target rotation
            modelTransform.transform.localRotation = Quaternion.Slerp(modelTransform.transform.localRotation,
                targetRotation, Time.deltaTime * 10);
        }
    }
}