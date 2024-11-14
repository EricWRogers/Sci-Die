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
        GlobalDoorManager.UnregisterDoor(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !playerInside)
        {
            playerInside = true;
            room.ActivateEnemies(); // Activate enemies in the room
            StartCoroutine(CloseAllDoorsWithDelay(1.5f)); // Delay for doors to close after player enters
        }
    }

    private System.Collections.IEnumerator CloseAllDoorsWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        room.CloseAllDoors(); // Close doors in the current room
    }

    public void OpenDoor()
    {
        if (doorRenderer != null) doorRenderer.enabled = false;
        if (doorCollider != null)
        {
            doorCollider.enabled = true;
            doorCollider.isTrigger = true;
        }
    }

    public void CloseDoor()
    {
        if (doorRenderer != null) doorRenderer.enabled = true;
        if (doorCollider != null)
        {
            doorCollider.enabled = true;
            doorCollider.isTrigger = false;
        }
    }
}
