using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
    public Dictionary<StateEnum, IState> States { get; private set; } = new Dictionary<StateEnum, IState>();

    private StateEnum state;
    
    public IInputController inputController { get; private set; }

    public StateManager(GameObject target, IInputController inputController, PlayerData data)
    {
        this.inputController = inputController;
        States.Add(StateEnum.Idle, new IdleState());
        States.Add(StateEnum.Moving, new MovingState(target, inputController, data));
    }
    
    public void ChangeState(StateEnum newState)
    {
        if (States.ContainsKey(state))
        {
            States[state].Exit();
        }
        state = newState;
        if (States.ContainsKey(state))
        {
            States[state].Exit();
        }
    }

    public void Update()
    {
        if (state != StateEnum.Idle && inputController.IsIdle)
        {
            ChangeState(StateEnum.Idle);
        } else if (inputController.MoveDirection != Vector3.zero)
        {
            ChangeState(StateEnum.Moving);
        }

        States[state].Update();
    }
}