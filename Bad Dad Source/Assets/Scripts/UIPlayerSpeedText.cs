using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This script updates the CarSpeedText gameobject text.
/// </summary>

public class UIPlayerSpeedText : MonoBehaviour
{
    float grossSpeed;
    string speed;
    TextMeshProUGUI playerSpeedText;

    private void Start()
    {
        // Initialize Speed Text.
        playerSpeedText = GetComponent<TextMeshProUGUI>();
        playerSpeedText.SetText("0 MPH");
    }

    private void SetSpeedText()
    {
        // Get the player speed from the MoveCar script on the player.
        grossSpeed = FindObjectOfType<MoveCar>().GetPlayerSpeed();
        // Change player speed to an integer and then to text.
        speed = Mathf.RoundToInt(grossSpeed).ToString();

        // Set the User Interface Speed Text to the player's speed.
        //TODO display speed as a positive number when driving backwards.
        playerSpeedText.SetText(speed + " MPH");
    }

    private void Update()
    {
        // Call SetSpeedText.
        SetSpeedText();
    }
}
