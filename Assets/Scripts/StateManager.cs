using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StateManager
{
    public Dictionary<StateEnum, IState> States { get; private set; } = new Dictionary<StateEnum, IState>();

    private StateEnum state;
    private float attackStateTime = 0;
    
    public IInputController inputController { get; private set; }
    public Animator animator { get; private set; }

    public StateManager(GameObject target, IInputController inputController, PlayerData data, 
        Animator animator, GameObject modelTransform, Transform shootPosition)
    {
        this.animator = animator;
        this.inputController = inputController;
        States.Add(StateEnum.Idle, new IdleState(inputController, animator));
        States.Add(StateEnum.Moving, new MovingState(target, inputController, data, animator, modelTransform));
        States.Add(StateEnum.Attacking, new AttackState(inputController, animator, modelTransform, data, shootPosition));
    }
    
    public void ChangeState(StateEnum newState)
    {
        if (States.ContainsKey(state))
        {
            States[state].Exit();
        }
        state = newState;
        States[state].Begin();
    }

    public void Begin()
    {
        ChangeState(StateEnum.Idle);
        States[state].Begin();
    }

    public void Update()
    {
        if (state == StateEnum.Attacking)
        {
            attackStateTime += Time.deltaTime;
        }
        
        if (state != StateEnum.Idle && inputController.IsIdle && (attackStateTime > 0.3f || attackStateTime == 0))
        {
            ChangeState(StateEnum.Idle);
        } else if (inputController.MoveDirection != Vector3.zero && (state != StateEnum.Attacking || (attackStateTime > 0.3f || attackStateTime == 0)))
        {
            ChangeState(StateEnum.Moving);
        }
        if(inputController.IsPunching || inputController.IsKicking)
        {
            ChangeState(StateEnum.Attacking);
            attackStateTime = 0;
        }

        States[state].Update();
    }
}