using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Default move speed
    public Rigidbody2D rb;

    public float health = 100f;   // Starting health
    public float maxHealth = 100f; // Max health cap
    public float damage = 10f;     // Starting damage
    public int dashCount = 1;      // Starting dash count

    private Vector2 moveDirection;

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetKey(KeyCode.Space))
        {
            moveSpeed = 25f;  // Increased speed when space is held down
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
