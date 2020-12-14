using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    [SerializeField] float driveSpeed = 1f;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        DriveCar();
    }

    private void DriveCar()
    {
        // Move up.
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.velocity = new Vector2(0, driveSpeed);
        }
        // Move down.
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.velocity = new Vector2(0, -driveSpeed);
        }

        // Move right.
        else if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(driveSpeed, 0);
        }
        // Move left.
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-driveSpeed, 0);
        }

        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
