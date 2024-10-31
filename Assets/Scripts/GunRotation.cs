using UnityEngine;
using UnityEngine.InputSystem;

public class GunRotation : MonoBehaviour
{
    private Camera mainCam;
    private PlayerControls controls;
    private Vector2 aimDirection;

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
        // Get the main camera
        mainCam = Camera.main;
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

        // Adjust the angle based on the parent's scale direction
        if (transform.parent.transform.localScale.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, angle + 180);
        }
    }
}
