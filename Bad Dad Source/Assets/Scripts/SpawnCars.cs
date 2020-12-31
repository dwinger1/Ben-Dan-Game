using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OBSOLETE CODE
/// 
/// </summary>

public class SpawnCars : MonoBehaviour
{
    [SerializeField] GameObject car;
    Rigidbody2D rb;
    [SerializeField] float speed, timeBetweenSpawns,
                    minimumTimeBetweenSpawns, maximumTimeBetweenSpawns;
    [SerializeField] int maxPop = 5;

    private void Start()
    {
        rb = car.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int pop = 0; pop < maxPop; pop++)
        {
            StartCoroutine(Spawn());
        }
        
    }

    IEnumerator Spawn()
    {
        Instantiate(car, transform);
        rb.velocity = new Vector2(0, -speed);

        yield return new WaitForSeconds(timeBetweenSpawns * Random.Range(minimumTimeBetweenSpawns, maximumTimeBetweenSpawns));
    }
}
