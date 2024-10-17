using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;

    private Vector2 moveDirection;
    
    public InputActionReference move;

    public ScrapManager sm;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        moveDirection = move.action.ReadValue<Vector2>();
        
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    public void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float orginalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(moveDirection.x * dashingPower, moveDirection.y * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = orginalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Scrap"))
        {
            Destroy(other.gameObject);
            sm.scrapCount++;
        }
    }
}