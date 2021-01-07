using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This script should handle all player movement ability. Anything that alters player movement should 
///  modify variables in this script.
/// </summary>

public class MoveCar : MonoBehaviour
{
    [SerializeField]
    float playerSpeed = 1f, acceleration = 100f, deceleration = 200f, playerHorizontalSpeed = 2f;
    Rigidbody2D rb;
    [Space] [Header("Allow Player To Drive Backwards")]
    [SerializeField] bool canDriveBackwards = false;

    private void Start()
    {
        // Access player rigidbody component.
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Call DriveCar.
        DriveCar();
    }

    public float GetPlayerSpeed()
    {
        // Other scripts can use this method to find the player's speed.
        return playerSpeed;
    }

    private void SetPlayerSpeed()
    {
        
        // Speed up.
        if (Input.GetAxis("Vertical") > 0)
        {
            playerSpeed += acceleration * Time.deltaTime;
        }
        // Brake.
        else if (Input.GetAxis("Vertical") < 0)
        {
            if (playerSpeed >= 0)
            {
                playerSpeed -= deceleration * Time.deltaTime;

                // Set player speed to 0 if canDriveBackwards is disabled and the speed goes below 0.
                if (!canDriveBackwards && playerSpeed < 0)
                {
                    playerSpeed = 0;
                }
            }
        }
    }

    private void TurnCar()
    {
        //TODO Research a better, more smooth way to move the car horizontally.
        
        // Move right.
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(playerHorizontalSpeed, 0);
        }
        // Move left.
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-playerHorizontalSpeed, 0);
        }

        else
        {
            // Set horizontal movement to zero when no keys are pressed.
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void DriveCar()
    {
        SetPlayerSpeed();
        TurnCar();
    }
}
