using UnityEngine;

public class MovingState : BaseState
{
    private readonly GameObject target;
    private readonly IInputController controller;
    private readonly PlayerData data;

    public MovingState(GameObject target, IInputController controller, PlayerData data)
    {
        this.controller = controller;
        this.target = target;
        this.data = data;
    }
    
    public override void Begin()
    {
        Debug.Log("Moving");
    }

    public override void Update()
    {
        target.transform.position +=
            target.transform.rotation * controller.MoveDirection * (data.Speed * Time.deltaTime);
    }
}