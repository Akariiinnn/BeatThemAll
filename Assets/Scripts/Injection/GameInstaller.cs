using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputController>().FromNew().AsSingle().NonLazy();
    }
}

public interface IInputController
{
    bool IsIdle { get;  }
    bool IsRunning { get;  }
    Vector3 MoveDirection { get; }
}

public class InputController : IInputController, ITickable
{
    public bool IsIdle { get; private set; }
    public bool IsRunning { get; private set; }
    public Vector3 MoveDirection { get; private set; }

    public void Tick()
    {
        IsIdle = !Input.anyKey;
        IsRunning = Input.GetKey(KeyCode.LeftShift);
        var moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.z = -1;
        }
        moveDirection.Normalize();
        MoveDirection = moveDirection;
    }
}
