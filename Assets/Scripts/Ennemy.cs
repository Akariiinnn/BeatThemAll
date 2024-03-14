using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Enemies data;
    private Vector3 direction = Vector3.left;
    private Vector3 spawnPosition;

    public event System.Action<Ennemy> OnHit;
    public event System.Action<Ennemy> OnDeath;

    private int health;

    void Start()
    {
        // Enregistrer la position de spawn de l'ennemi
        spawnPosition = transform.position;
        health = data.Health;
    }

    private void Update()
    {
        // Vérifier la distance entre l'ennemi et le joueur
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // Si le joueur est suffisamment proche, ajuster la direction vers le joueur
            if (distanceToPlayer < data.MaxOffset && distanceToPlayer > 0.5f)
            {
                direction = (player.transform.position - transform.position).normalized;
            }
            else
            {
                // Sinon, revenir à la direction par défaut
                // Direction aléatoire à l'intérieur du spawnRadius
                Vector3 randomDirection = UnityEngine.Random.insideUnitSphere;
                randomDirection.y = 0;
                direction = randomDirection.normalized;
            }
        }

        // Déplacer l'ennemi dans la direction actuelle
        transform.position += direction * data.Speed * Time.deltaTime;
    }

   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>() != null)
        {
            OnHit?.Invoke(this);
            if (health > 0)
            {
                health -= collision.gameObject.GetComponent<Projectile>().Damage;
            }
            else
            {
                OnDeath?.Invoke(this);
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}

