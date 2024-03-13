using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] private float maxOffset = 5;
    [SerializeField] private float speed = 5;
    private Vector3 direction = Vector3.left;

    public event Action<Ennemy> OnHit;

    private void Update()
    {
        if(transform.localPosition.magnitude > maxOffset)
        {
            direction = -direction;
        }

        transform.position += direction * speed * Time.deltaTime;
    }

   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>() != null)
        {
            OnHit?.Invoke(this);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }*/
}
