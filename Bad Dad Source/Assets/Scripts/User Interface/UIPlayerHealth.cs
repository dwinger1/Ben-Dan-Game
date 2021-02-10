using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayerHealth : MonoBehaviour
{
    private int health;
    TextMeshProUGUI playerHealthText;

    private void Start()
    {
        // Initialize Health Text.
        playerHealthText = GetComponent<TextMeshProUGUI>();
        playerHealthText.SetText("100 HP");
    }

    private int SetHealth()
    {
        // Get the health value from the PlayerStats script.
        health = FindObjectOfType<PlayerStats>().GetPlayerHealth();
        return health;
    }

    private void SetHealthText()
    {
        // Set the health text to the integer gathered in the SetHealth method.
        playerHealthText.SetText(SetHealth().ToString() + " HP");
    }

    private void Update()
    {
        // Call SetHealthText.
        SetHealthText();
    }
}
