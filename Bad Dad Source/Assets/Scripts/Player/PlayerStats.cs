using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles player health.
/// </summary>

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    
    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public int DamagePlayer(int damage)
    {
        if (playerHealth > 0)
        {
            playerHealth -= damage;
        }
        else
        {
            KillPlayer();
        }
        return playerHealth;
    }
    
    public void KillPlayer()
    {
        Destroy(gameObject);
    }

    public int HealPlayer(int health)
    {
        playerHealth += health;
        return playerHealth;
    }
}
