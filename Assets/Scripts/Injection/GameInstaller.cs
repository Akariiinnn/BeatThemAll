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
    bool IsRunning { get; set; }
    bool IsKicking { get;  }
    bool IsPunching { get;  }
    bool IsJumping { get;  }
    Vector3 MoveDirection { get; }
}

public class InputController : IInputController, ITickable
{
    public bool IsIdle { get; private set; }
    public bool IsRunning { get; set; }
    public bool IsPunching { get; private set; }
    public bool IsKicking { get; private set; }
    public bool IsJumping { get; private set; }
    public Vector3 MoveDirection { get; private set; }

    public void Tick()
    {
        var moveDirection = Vector3.zero;
        IsIdle = !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S);
        IsRunning = Input.GetKey(KeyCode.LeftShift);
        IsKicking = Input.GetKeyDown(KeyCode.R);
        IsPunching = Input.GetKeyDown(KeyCode.F);
        IsJumping = Input.GetKeyDown(KeyCode.Space);
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
