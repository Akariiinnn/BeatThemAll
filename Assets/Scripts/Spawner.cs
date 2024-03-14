using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] entityPrefabs;
    [SerializeField] private int maxSpawnCount = 5;
    [SerializeField] private float spawnRadius = 5f; // Rayon autour du spawner où les ennemis peuvent apparaître
    [SerializeField] private ScoreUI scoreUI;

    private int spawnCount;
    private bool hasBeenActivated;

    void Start()
    {
        hasBeenActivated = false;
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < maxSpawnCount; i++)
        {
            // Calculer une position aléatoire à l'intérieur du rayon autour du spawner
            Vector3 spawnPosition = transform.position + UnityEngine.Random.insideUnitSphere * spawnRadius;
            spawnPosition.y = 1;
            GameObject selectedPrefab = entityPrefabs[i];
            Debug.Log("Spawn Position: " + spawnPosition);
            var instance = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
            
            instance.GetComponent<Ennemy>().OnHit += OnEnemyHit;
            instance.GetComponent<Ennemy>().OnDeath += OnEnemyDeath;

            spawnCount++;
        }
    }

    private void OnEnemyHit(Ennemy enemy)
    {
        Debug.Log(enemy);
    }

    private void OnEnemyDeath(Ennemy enemy)
    {
        scoreUI.AddScorePoint();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null && !hasBeenActivated)
        {
            hasBeenActivated = true;
            SpawnEnemies();
        }
    }

    public void EnemyDestroyed()
    {
        spawnCount--;
    }
}
