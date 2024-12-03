using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Movement Variables
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public Vector2 moveDirection;
    private PlayerControls controls;

    // Combat and Upgrade Variables
    public float damage = 10f;

    // Dash Variables
    public bool canDash = true;
    public bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    public Animator animator;

    // Add reference to the SpriteRenderer of the main player sprite
    public SpriteRenderer playerSpriteRenderer;



    private void Awake()
    {
        // Initialize the controls
        controls = new PlayerControls();

        // Set up the movement input callback
        controls.Player.Move.performed += ctx => moveDirection = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveDirection = Vector2.zero;

        // Set up the dash input callback
        controls.Player.Dash.performed += ctx => AttemptDash();

        playerSpriteRenderer = GetComponent<SpriteRenderer>();



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
        FlipSprite();
    }

    void FixedUpdate()
    {
        if (isDashing)
            return;

        // Apply movement to Rigidbody2D
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        animator.SetFloat("xVel", Mathf.Abs(rb.velocity.x));
    }


    // Attempt to perform a dash if conditions are met
    private void AttemptDash()
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }

    // Dash Coroutine
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(moveDirection.x * dashingPower, moveDirection.y * dashingPower);
        GetComponent<CapsuleCollider2D>().enabled = false;

        yield return new WaitForSeconds(dashingTime);

        rb.gravityScale = originalGravity;
        isDashing = false;

        // Cooldown to reset dash ability
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        GetComponent<CapsuleCollider2D>().enabled = true;


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Scrap"))
        {
            Destroy(other.gameObject);
            
        }
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

            /*case PickUp.PickupType.DashCount:
                IncreaseDashCount((int)pickup.value);  // Increase player's dash count
                break;*/
        }
    }

    // Method to flip the sprite based on the movement direction
    private void FlipSprite()
    {
        if (moveDirection.x > 0) // Moving right
        {
            playerSpriteRenderer.flipX = false;
        }
        else if (moveDirection.x < 0) // Moving left
        {
            playerSpriteRenderer.flipX = true;
        }
        
    }

}
