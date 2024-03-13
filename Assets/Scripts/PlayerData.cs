using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float speed = 10;
    [SerializeField] private Vector3 direction = Vector3.forward;
    [SerializeField] private GameObject prefab;
    
    public float Speed
    {
        get => speed;
        set => speed = value;
    }
    
    public Vector3 Direction
    {
        get => direction;
        set => direction = value;
    }
    
    public GameObject Prefab
    {
        get => prefab;
        set => prefab = value;
    }
}
