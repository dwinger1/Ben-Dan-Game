using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script changes the background speed based on how fast the player is moving.
/// </summary>

public class BackgroundScroller : MonoBehaviour
{
    float playerSpeed;
    float backgroundSpeed;
    [SerializeField] float speedDividend = 1;
    Material myMaterial;
    Vector2 offSet;

    void Start()
    {
        // Get the background material.
        myMaterial = GetComponent<Renderer>().material;
    }

    // Get the speed the player is supposed to be moving at from the MoveCar script's inputs.
    private float Speed()
    {
        // Utilize the player speed found in the MoveCar script. This keeps the inputs
        // all in one script.
        playerSpeed = FindObjectOfType<MoveCar>().GetPlayerSpeed();
        return playerSpeed;
    }

    private void SetBackgroundSpeed(float playerSpeed)
    {
        // Set the background speed the same as the player speed, but tune it with speedDividend to 
        // make a more realistic background movement amount.
        backgroundSpeed = playerSpeed / speedDividend;

        // Declare an "offset" that will be moving the texture, 
        // lock it horizontally, and move it based on the player's speed.
        offSet = new Vector2(0f, backgroundSpeed);
    }

    private void MoveBackground()
    {
        // Change the offSet amount.
        SetBackgroundSpeed(Speed());

        // Move the background using the offSet amount.
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }

    void Update()
    {
        MoveBackground();
    }
}
