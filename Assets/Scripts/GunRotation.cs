using UnityEngine;

public class GunFollowAndRotate : MonoBehaviour
{
    private Camera mainCam;

    private void Start()
    {
        // Get the main camera
        mainCam = Camera.main;
    }

    void Update()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Ensure we're working in 2D space

        // Calculate the direction to the mouse position
        Vector3 direction = mousePos - transform.position;

        // Calculate the angle in degrees and apply the rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Adjust the angle by adding 180 degrees
        transform.rotation = Quaternion.Euler(0, 0, angle + 180);

        // Optionally, move the GameObject to the mouse position
        transform.position = mousePos;
    }
}
