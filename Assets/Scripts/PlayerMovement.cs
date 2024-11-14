using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Movement Variables
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    private Vector2 moveDirection;
    private PlayerControls controls;

    // Combat and Upgrade Variables
    public float damage = 10f;
    public int dashCount = 1;

    // Dash Variables
    public bool canDash = true;
    public bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

    private void Awake()
    {
        // Initialize the controls
        controls = new PlayerControls();

        // Set up the movement input callback
        controls.Player.Move.performed += ctx => moveDirection = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveDirection = Vector2.zero;

        // Set up the dash input callback
        controls.Player.Dash.performed += ctx => AttemptDash(); 
    }

    private void OnEnable()
    {
        // Enable the input action map
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        // Disable the input action map
        controls.Player.Disable();
    }

    void Update()
    {
        // No need to check for dash input here anymore
        if (isDashing)
            return;
    }

    void FixedUpdate()
    {
        if (isDashing)
            return;

        // Apply movement to Rigidbody2D
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    // Attempt to perform a dash if conditions are met
    private void AttemptDash()
    {
        if (canDash && dashCount > 0)
        {
            StartCoroutine(Dash());
        }
    }

    // Dash Coroutine
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        dashCount--;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(moveDirection.x * dashingPower, moveDirection.y * dashingPower);

        yield return new WaitForSeconds(dashingTime);

        rb.gravityScale = originalGravity;
        isDashing = false;

        // Cooldown to reset dash ability
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Scrap"))
        {
            Destroy(other.gameObject);
            
        }
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
    /*void OnTriggerEnter2D(Collider2D other)
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
    }*/

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
