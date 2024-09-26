using UnityEngine;
using System.Diagnostics; // For debugging

public class WeaponUpgrade : MonoBehaviour
{
    // Initial weapon damage
    public float baseDamage = 10f;

    // Multiplier for weapon upgrades (exposed in the Inspector)
    public float upgradeMultiplier = 1f;

    // Maximum damage limit (exposed in the Inspector)
    public float maxDamage = 100f;

    // Current damage with upgrades applied
    private float currentDamage;

    // Renderer component to change the cube's color
    private Renderer cubeRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize current damage to base damage (no upgrades yet)
        currentDamage = baseDamage;

        // Get the Renderer component to change color
        cubeRenderer = GetComponent<Renderer>();

        // Set the initial color to white
        if (cubeRenderer != null)
        {
            cubeRenderer.material.color = Color.white;
        }
    }

    // Function to upgrade the weapon with the current multiplier
    public void UpgradeWeapon()
    {
        // Multiply the current damage by the upgrade multiplier
        currentDamage *= upgradeMultiplier;

        // Clamp the current damage to not exceed the maximum damage
        currentDamage = Mathf.Min(currentDamage, maxDamage);

        UpdateWeaponDamage();
    }

    // Function to calculate and log the current damage
    void UpdateWeaponDamage()
    {
        UnityEngine.Debug.Log("Weapon upgraded! Current damage: " + currentDamage);
        // Debugger to pause the game for inspection (optional)
        Debugger.Break();
    }

    // Method to simulate weapon usage
    public void Attack()
    {
        // Use current damage for an attack (printing the damage to the console)
        UnityEngine.Debug.Log("Weapon attack with damage: " + currentDamage);
    }

    // Change the cube's color when upgrading the weapon
    void ChangeColor(Color newColor)
    {
        if (cubeRenderer != null)
        {
            cubeRenderer.material.color = newColor;
        }
    }

    // Simulate a weapon upgrade, e.g., when picking up an upgrade
    void OnUpgrade()
    {
        // Upgrade the weapon using the multiplier from the Inspector
        UpgradeWeapon();

        // Change the cube's color to indicate the upgrade (e.g., red)
        ChangeColor(Color.red);

        UnityEngine.Debug.Log("Weapon upgrade applied: Multiplier is now " + upgradeMultiplier);
    }

    // For testing, simulate an upgrade when pressing a key (space bar)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnUpgrade(); // Apply upgrade when space is pressed
        }

        if (Input.GetMouseButtonDown(0)) // Left mouse button for attack
        {
            Attack(); // Simulate attack when left-clicking
        }
    }
}
