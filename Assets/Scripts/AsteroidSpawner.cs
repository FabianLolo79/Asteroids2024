using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float trajectoryVariance = 15.0f;
    public float spawnRate = 2.0f; //tiempo de generaci�n de cada asteroide 2 segundos.
    public float spawnDistance = 15.0f;
    public int spawnAmount = 1; // cantidad de creaci�n de Asteroides

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn),spawnRate, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance; //
            Vector3 spawnPoint = this.transform.position + spawnDirection; // punto de creaci�n

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.maxSize, asteroid.maxSize);
            asteroid.SetTrayectory(rotation * -spawnDirection);
        }
    }
}
