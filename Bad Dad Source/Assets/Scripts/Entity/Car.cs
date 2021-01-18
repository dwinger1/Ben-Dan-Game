using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will hold car attributes, such as speed, steadiness, for cars spawning in the left lane.
/// </summary>

public class Car : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private float UpdateSpeed()
    {
        // Take player speed, set speed of car to player speed divided by carspawner speed dividend.
        speed = speed + FindObjectOfType<MoveCar>().GetPlayerSpeed();
        speed /= GetComponentInParent<CarSpawner>().GetSpeedDividend();
        return speed;
    }

    private void Move()
    {
        // Set the carVelocity Vector to the velocity of the rigidbody to move the car.
        rb.velocity = new Vector2(0, -UpdateSpeed());
    }
}
