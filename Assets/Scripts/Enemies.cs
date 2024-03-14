using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemies", menuName = "Enemies")]
public class Enemies : ScriptableObject
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float maxOffset = 5;
    [SerializeField] private int health = 25;
    
    public float Speed
    {
        get => speed;
        set => speed = value;
    }
    
    public float MaxOffset
    {
        get => maxOffset;
        set => maxOffset = value;
    }
    
    public int Health
    {
        get => health;
        set => health = value;
    }
}
