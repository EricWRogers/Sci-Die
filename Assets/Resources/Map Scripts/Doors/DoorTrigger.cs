using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorTrigger : MonoBehaviour
{
    public Room room; // Reference to the room this door belongs to
    private Collider2D doorCollider;
    private SpriteRenderer doorRenderer;
    private GameObject[] childColliders; // Array to hold all child colliders
    private bool playerInside = false;

    private void Start()
    {
        doorCollider = GetComponent<Collider2D>();
        doorRenderer = GetComponent<SpriteRenderer>();

        // Find all child objects tagged as "DoorChildCollider"
        childColliders = GetComponentsInChildren<Transform>(true) // Include inactive objects
            .Where(t => t.CompareTag("DoorChildCollider"))
            .Select(t => t.gameObject)
            .ToArray();

        if (childColliders.Length == 0)
        {
            Debug.LogWarning("DoorTrigger: No child colliders with tag 'DoorChildCollider' found.");
        }

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
            playerInside = true;
            room.ActivateEnemies(); // Activate enemies in the room
            StartCoroutine(CloseAllDoorsWithDelay(0.0f)); // Delay for door closure
        }
    }

    private System.Collections.IEnumerator CloseAllDoorsWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        GlobalDoorManager.CloseDoorsForRoom(room); // Close doors in this room only
    }

    public void OpenDoor()
    {
        if (doorRenderer != null) doorRenderer.enabled = false;

        if (doorCollider != null)
        {
            doorCollider.enabled = true; // Re-enable main door collider
            doorCollider.isTrigger = true; // Allow player to pass through
        }

        foreach (GameObject child in childColliders)
        {
            if (child != null)
                child.SetActive(false); // Deactivate all child colliders when the door is open
        }
    }

    public void CloseDoor()
    {
        if (doorRenderer != null) doorRenderer.enabled = true;

        if (doorCollider != null)
        {
            doorCollider.enabled = false; // Disable main door collider when closed
        }

        foreach (GameObject child in childColliders)
        {
            if (child != null)
                child.SetActive(true); // Activate all child colliders when the door is closed
        }
    }
}
