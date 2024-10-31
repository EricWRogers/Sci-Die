using UnityEngine;
using UnityEngine.InputSystem;

public class GunRotation : MonoBehaviour
{
    private Camera mainCam;
    private PlayerControls controls;
    private Vector2 aimDirection;
    private Transform spriteTransform;

    private void Awake()
    {
        // Initialize the controls
        controls = new PlayerControls();

        // Set up the aim input callback for right stick
        controls.Player.Aim.performed += ctx => aimDirection = ctx.ReadValue<Vector2>();
        controls.Player.Aim.canceled += ctx => aimDirection = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void Start()
    {
        // Get the main camera and the sprite's transform
        mainCam = Camera.main;
        spriteTransform = transform; // Assuming this script is on the sprite's GameObject
    }

    void Update()
    {
        Vector3 direction;

        // If the right stick is moved, use it for aiming
        if (aimDirection.magnitude > 0.1f)
        {
            direction = new Vector3(aimDirection.x, aimDirection.y, 0).normalized;
        }
        else
        {
            // Otherwise, use the mouse position for aiming
            Vector3 mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos.z = 0; // Ensure we're working in 2D space
            direction = (mousePos - transform.position).normalized;
        }

        // Calculate the angle in degrees and apply the rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Flip the sprite based on the aim direction
        if (direction.x < 0)
            spriteTransform.localScale = new Vector3(1, -1, -1); // Flip to left
        else
            spriteTransform.localScale = new Vector3(1, 1, 1); // Reset to right
    }
}
