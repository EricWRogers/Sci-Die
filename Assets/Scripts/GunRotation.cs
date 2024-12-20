using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunRotation : MonoBehaviour
{
    public Camera mainCam;
    private PlayerControls controls;
    private Vector2 aimDirection;
    private SpriteRenderer spriteRenderer;
    private Transform playerTransform; // Reference to the player's transform
    private Vector3 offset = new Vector3(-.132f, .143f, 0); // Default gun offset

    private void Awake()
    {
        controls = new PlayerControls();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        controls.Player.Aim.performed += ctx => aimDirection = ctx.ReadValue<Vector2>();
        controls.Player.Aim.canceled += ctx => aimDirection = Vector2.zero;

        // Get the player's transform
        playerTransform = transform.parent; // Assuming gun is a child of the player
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
        mainCam = Camera.main;
    }

    void Update()
    {
        UpdatePositionBasedOnMovement();

        Vector3 direction;

        GameObject Starter = this.gameObject.transform.GetChild(0).gameObject;
        GameObject G2 = this.gameObject.transform.GetChild(1).gameObject;
        GameObject Rail2 = this.gameObject.transform.GetChild(2).gameObject;
        GameObject Shotty = this.gameObject.transform.GetChild(3).gameObject;
        GameObject Smg = this.gameObject.transform.GetChild(4).gameObject;
        GameObject Drone = this.gameObject.transform.GetChild(6).gameObject;


        if (aimDirection.magnitude > 0.1f)
        {
            direction = new Vector3(aimDirection.x, aimDirection.y, 0).normalized;
        }
        else
        {
            Vector3 mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos.z = 0;
            direction = (mousePos - transform.position).normalized;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        spriteRenderer.flipY = direction.x < 0;

        Starter.GetComponent<SpriteRenderer>().flipY = direction.x < 0;
        G2.GetComponent<SpriteRenderer>().flipY = direction.x < 0;
        Rail2.GetComponent<SpriteRenderer>().flipY = direction.x < 0;
        Shotty.GetComponent<SpriteRenderer>().flipY = direction.x < 0;
        Smg.GetComponent<SpriteRenderer>().flipY = direction.x < 0;
        Drone.GetComponent<SpriteRenderer>().flipY = direction.x < 0;

    }

    private void UpdatePositionBasedOnMovement()
    {
        if (playerTransform == null) return;

        // Check the player's movement direction and update the gun's offset
        var playerMovement = playerTransform.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            if (playerMovement.moveDirection.x > 0)
            {
                offset = new Vector3(-.132f, .143f, 0); // Right side
            }
            else if (playerMovement.moveDirection.x < 0)
            {
                offset = new Vector3(.132f, .143f, 0); // Left side
            }

            // Update the gun's position relative to the player
            transform.localPosition = offset;
        }
    }
}
