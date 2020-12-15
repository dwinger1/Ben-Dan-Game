using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Car acceleration
//TODO 

public class MoveCar : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1f;
    Rigidbody2D rb;

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

    private void DriveCar()
    {
        //// Move up.
        //if (Input.GetAxis("Vertical") > 0)
        //{
        //    rb.velocity = new Vector2(0, playerSpeed);
        //}
        //// Move down.
        //else if (Input.GetAxis("Vertical") < 0)
        //{
        //    rb.velocity = new Vector2(0, -playerSpeed);
        //}

        // Move right.
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(playerSpeed, 0);
        }
        // Move left.
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-playerSpeed, 0);
        }

        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
