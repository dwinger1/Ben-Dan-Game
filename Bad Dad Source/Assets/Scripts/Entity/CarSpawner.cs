﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script spawns cars in left lane traffic.
/// </summary>
public class CarSpawner : MonoBehaviour
{
    bool spawn = true;

    [SerializeField] float speedDividend = 2; // Make the speed of cars match the speed of the background.

    [Header("Minimum and maximum time between new cars")]
    [SerializeField] float spawnMinTime = 1f, spawnMaxTime = 5f;

    [SerializeField] Car[] carPrefab; // Allow editor to drag and drop any number of car prefabs onto this spawner.

    IEnumerator Start()
    {
        while (spawn)
        {
            // Wait for a random time between min and max to spawn a new car.
            yield return new WaitForSeconds(Random.Range(spawnMinTime, spawnMaxTime));
            Spawn();
        }
    }

    public float GetSpeedDividend()
    {
        return speedDividend;
    }

    private Car SpawnCar()
    {
        // Pick a random car from the list of prefabs added to this spawner.
        int carIndex = Random.Range(0, carPrefab.Length);
        Debug.Log("Car prefab from spawn car" + carPrefab);
        return carPrefab[carIndex];
    }

    private void Spawn()
    {
        // Instantiate a new car gameobject prefab picked from SpawnCar method.
        Car newCar = Instantiate(SpawnCar(), transform.position, transform.rotation) as Car;

        // Nest the newly spawned car under the Car Spawner gameobject in the hierarchy.
        newCar.transform.parent = transform;
    }

    public void StopSpawning()
    {
        // Add a way to shut off this spawner from another script.
        spawn = false;
        Debug.Log("Stop spawning cars!");
    }
}
