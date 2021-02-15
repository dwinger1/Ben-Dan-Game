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
    #region Initialization, Setup, Cache
    [SerializeField]
    float playerSpeed = 1f, maxPlayerSpeed, offRoadSpeed, acceleration = 10f, deceleration = 2f, brakeSpeed = 200f,
            playerHorizontalSpeed = 0.008f;
    float cacheMaxPlayerSpeed;
    float turnInput;
    bool gasInput, brakeInput, isOnRoad = true;
    Rigidbody2D rb;
    [SerializeField] Collider2D myCollider;
    LayerMask roadLayer;
    [Space] [Header("Allow Player To Drive Backwards")]
    [SerializeField] bool canDriveBackwards = false;

    private void Start()
    {
        // Access player rigidbody component.
        rb = GetComponent<Rigidbody2D>();
        cacheMaxPlayerSpeed = maxPlayerSpeed;
        roadLayer = LayerMask.GetMask("Road");
    }

    /// <summary>
    /// Caches the different player inputs.
    /// </summary>
    private void Inputs()
    {
        turnInput = Input.GetAxis("Horizontal");
        gasInput = Input.GetButton("Gas");
        brakeInput = Input.GetButton("Brake");
    }
    #endregion

    private void Update()
    {
        // Call DriveCar.
        DriveCar();
    }

    private void DriveCar()
    {
        Inputs();
        SetPlayerSpeed(isOnRoad);
        TurnCar(turnInput);
    }

    #region Control Car Moving "Forward"
    /// <summary>
    /// Other scripts can use this method to find the player's speed.
    /// </summary>
    /// <returns>Returns float playerSpeed that's modified in the MoveCar script.</returns>
    public float GetPlayerSpeed()
    {
        return playerSpeed;
    }

    public float GetMaxPlayerSpeed()
    {
        return maxPlayerSpeed;
    }
    /// <summary>
    /// This method will be used to control the player speed using the Gas and Brake inputs.
    /// </summary>
    private void SetPlayerSpeed(bool isOnRoad)
    {
        // Speed up.
        if (gasInput)
        {
            if (CheckCarIsOnRoad())
            {
                maxPlayerSpeed = cacheMaxPlayerSpeed;
            }
            else
            {
                maxPlayerSpeed = offRoadSpeed;
            }
                
            if (playerSpeed < maxPlayerSpeed)
            {
                playerSpeed += acceleration;
            }
            else
            {
                playerSpeed = maxPlayerSpeed;
            }

            //Debug.Log("Player Speed Is " + playerSpeed);
        }

        else if (!gasInput && playerSpeed >= 0)
        {
            playerSpeed -= deceleration;
            if (playerSpeed < 0)
            {
                playerSpeed = 0;
            }
            //Debug.Log("Player Speed Is Decelerating " + playerSpeed);
        }

        // Brake.
        if (brakeInput && playerSpeed >= 0)
        {
            if (playerSpeed >= 0)
            {
                playerSpeed -= brakeSpeed;
                //Debug.Log("Player is braking" + playerSpeed);
                // Set player speed to 0 if canDriveBackwards is disabled and the speed goes below 0.
                if (!canDriveBackwards && playerSpeed < 0)
                {
                    playerSpeed = 0;
                }
            }
        }
    }

    /// <summary>
    /// Check if the car is on the road.
    /// </summary>
    private bool CheckCarIsOnRoad()
    {
        if (myCollider.IsTouchingLayers(roadLayer))
        {
            isOnRoad = true;
        }
        else
        {
            isOnRoad = false;
        }
        return isOnRoad;
    }

    #endregion
    #region Control Car "Turning"
    /// <summary>
    /// Move the player horizontally.
    /// </summary>
    /// <param name="input">Takes the input axis for steering the car.</param>
    private void TurnCar(float input)
    {
        transform.Translate(Vector2.right * input * playerHorizontalSpeed * Time.deltaTime);
    }
    #endregion
}
