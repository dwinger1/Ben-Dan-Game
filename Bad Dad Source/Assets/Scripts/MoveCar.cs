using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    [SerializeField]
    float playerSpeed = 1f, acceleration = 100f, deceleration = 200f, playerHorizontalSpeed = 2f;
    Rigidbody2D rb;
    [SerializeField] bool canDriveBackwards = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        DriveCar();
    }

    public float GetPlayerSpeed()
    {
        return playerSpeed;
    }

    private void SetPlayerSpeed()
    {
        
        // Move up.
        if (Input.GetAxis("Vertical") > 0)
        {
            playerSpeed += acceleration * Time.deltaTime;
        }
        // Move down.
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
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void DriveCar()
    {
        SetPlayerSpeed();
        TurnCar();
    }
}
