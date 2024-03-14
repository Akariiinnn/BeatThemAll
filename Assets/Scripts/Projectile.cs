using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 35;
    [SerializeField] private Vector3 direction = Vector3.forward;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private int damage = 10;
    [SerializeField] private Rigidbody body;
    
    private float currentLifetime = 0;

    public event Action onHit;
    
    // Start is called before the first frame update
    void Start()
    {
        body.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        currentLifetime += Time.deltaTime;
        if (currentLifetime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Ennemy>() != null)
        {
            onHit?.Invoke();
        }
    }
    
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
    
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    
    public void SetLifeTime(float lifeTime)
    {
        this.lifeTime = lifeTime;
    }
    
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public int Damage
    {
        get => this.damage;
    }
}
