using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement Variables
    public float moveSpeed = 5f; 
    public Rigidbody2D rb;

    private Vector2 moveDirection;
    public InputActionReference move;

    // Combat and Upgrade Variables
    public float damage = 10f;  
    public int dashCount = 1;

    // Dash Variables
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    void Update()
    {
        if (isDashing)
            return;

        // Handle Movement Inputs
        moveDirection = move.action.ReadValue<Vector2>();

        // Dash Action
        if (Input.GetKeyDown(KeyCode.Space) && canDash && dashCount > 0)
        {
            StartCoroutine(Dash());
            dashCount--;  // Decrease dash count after dashing
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
            return;

        // Apply movement to Rigidbody2D
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    // Dash Coroutine
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(moveDirection.x * dashingPower, moveDirection.y * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    // Method to Increase Dash Count
    public void IncreaseDashCount(int value)
    {
        dashCount += value;
    }

    // Method to Increase Damage
    public void IncreaseDamage(float value)
    {
        damage += value;
    }

    // Pickup Collision Detection
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickup"))
        {
            PickUp pickup = other.GetComponent<PickUp>();
            if (pickup != null)
            {
                ApplyPickup(pickup);
                Destroy(other.gameObject); // Destroy the pick-up after use
            }
        }
    }

    // Apply the effect of the pickup
    void ApplyPickup(PickUp pickup)
    {
        Health playerHealth = GetComponent<Health>(); // Reference to Health script

        switch (pickup.type)
        {
            case PickUp.PickupType.Health:
                if (playerHealth != null)
                {
                    playerHealth.Heal(pickup.value);  // Use existing Health script to heal
                }
                break;

            case PickUp.PickupType.Damage:
                IncreaseDamage(pickup.value);  // Increase player's damage
                break;

            case PickUp.PickupType.DashCount:
                IncreaseDashCount((int)pickup.value);  // Increase player's dash count
                break;
        }
    }
}