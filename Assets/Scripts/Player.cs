using System.Collections;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData _data;

    private StateManager stateManager;

    private IInputController inputController;

    [Inject]
    private void Construct(IInputController controller)
    {
        inputController = controller;
        stateManager = new StateManager(gameObject, inputController, _data);
    }

    private void Start()
    {
    }

    void Update()
    {
        stateManager.Update();
    }
}