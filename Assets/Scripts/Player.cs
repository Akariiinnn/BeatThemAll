using System.Collections;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData _data;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject modelTransform;
    [SerializeField] private Transform shootPosition;
    [SerializeField] private AudioManager audioManager;

    private StateManager stateManager;

    private IInputController inputController;

    [Inject]
    private void Construct(IInputController controller)
    {
        inputController = controller;
        stateManager = new StateManager(gameObject, inputController, _data, animator, modelTransform, shootPosition, audioManager);
    }

    void Update()
    {
        stateManager.Update();
    }
}