using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Room room; // Reference to the room this door belongs to
    private Collider2D doorCollider;
    private SpriteRenderer doorRenderer;
    private bool playerInside = false;

    private void Start()
    {
        doorCollider = GetComponent<Collider2D>();
        doorRenderer = GetComponent<SpriteRenderer>();

        OpenDoor(); // Start with the door open
        GlobalDoorManager.RegisterDoor(this); // Register this door globally
    }

    private void OnDestroy()
    {
        GlobalDoorManager.UnregisterDoor(this); // Unregister this door when destroyed
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !playerInside)
        {
            playerInside = true; // Player has entered the room

            room.ActivateEnemies(); // Activate enemies in the room

            // Start a coroutine to handle the delayed door closure
            StartCoroutine(CloseAllDoorsWithDelay(1.0f)); // Delay of 0.5 seconds
        }
    }

    private System.Collections.IEnumerator CloseAllDoorsWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        GlobalDoorManager.CloseAllDoors(); // Close all registered doors globally
    }

    public void OpenDoor()
    {
        if (doorRenderer != null) doorRenderer.enabled = false;
        if (doorCollider != null)
        {
            doorCollider.enabled = true;
            doorCollider.isTrigger = true; // Allow player to pass through
        }
    }

    public void CloseDoor()
    {
        if (doorRenderer != null) doorRenderer.enabled = true;
        if (doorCollider != null)
        {
            doorCollider.enabled = true;
            doorCollider.isTrigger = false; // Block player from passing through
        }
    }
}
