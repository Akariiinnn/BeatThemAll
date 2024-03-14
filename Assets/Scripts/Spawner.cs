using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] entityPrefabs;
    [SerializeField] private int maxSpawnCount = 5;
    [SerializeField] private float spawnRadius = 5f; // Rayon autour du spawner où les ennemis peuvent apparaître

    private int spawnCount;

    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < maxSpawnCount; i++)
        {
            // Calculer une position aléatoire à l'intérieur du rayon autour du spawner
            Vector3 spawnPosition = transform.position + UnityEngine.Random.insideUnitSphere * spawnRadius;
            spawnPosition.y = 0;
            GameObject selectedPrefab = entityPrefabs[i];
            Debug.Log("Spawn Position: " + spawnPosition);
            var instance = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
            
            instance.GetComponent<Ennemy>().OnHit += OnEnemyHit;

            spawnCount++;
        }
    }

    private void OnEnemyHit(Ennemy enemy)
    {
        Debug.Log(enemy);
    }

    public void EnemyDestroyed()
    {
        spawnCount--;
    }
}
