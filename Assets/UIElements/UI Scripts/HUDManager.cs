using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    // HUD UI Elements
    public TextMeshProUGUI dodgeCountText;        // Text for displaying dodge count
    public Slider weaponCooldownSlider;           // Slider for displaying weapon cooldown
    public TextMeshProUGUI droneAttackText;       // Text for drone attack status
    public TextMeshProUGUI weaponText;            // Text for displaying current weapon
    public TextMeshProUGUI scrapCountText;        // Text for displaying scrap count

    // Health and Dodge Properties
    private int maxDodges = 3;                    // Maximum number of dodges
    private int currentDodges;                    // Current dodge count

    // Weapon Cooldown Properties
    private float weaponCooldown = 5f;            // Cooldown time for weapon
    private float currentWeaponCooldown = 0f;
    private bool isWeaponOnCooldown = false;

    // Drone Attack and Scrap Count as Objects (placeholders for now)
    public GameObject droneAttackObject;          // Placeholder for the actual drone attack object
    public GameObject scrapObject;                // Placeholder for the actual scrap object

    private bool droneReady = true;               // If drone attack is ready
    private string currentWeapon = "Laser Gun";   // Current weapon
    private int scrapCount = 0;                   // Scrap collected by the player

    void Start()
    {
        currentDodges = maxDodges;
        weaponCooldownSlider.gameObject.SetActive(false); // Hide weapon cooldown slider initially
        UpdateDodgeCountUI();
        UpdateDroneAttackUI();
        UpdateWeaponUI();
        UpdateScrapCountUI();
    }

    void Update()
    {
        // Weapon cooldown logic
        if (isWeaponOnCooldown)
        {
            currentWeaponCooldown -= Time.deltaTime;
            weaponCooldownSlider.value = currentWeaponCooldown / weaponCooldown; // Update the slider value
            
            if (currentWeaponCooldown <= 0)
            {
                isWeaponOnCooldown = false;
                currentWeaponCooldown = 0;
                weaponCooldownSlider.gameObject.SetActive(false); // Hide the slider when cooldown is over
            }
        }
    }

    // Update dodge count UI
    void UpdateDodgeCountUI()
    {
        if (dodgeCountText != null)
            dodgeCountText.text = "Dodges: " + currentDodges;
        else
            Debug.LogWarning("Dodge Count Text is not assigned!");
    }

    // Update scrap count UI
    void UpdateScrapCountUI()
    {
        if (scrapCountText != null)
            scrapCountText.text = "Scrap: " + scrapCount;
        else
            Debug.LogWarning("Scrap Count Text is not assigned!");
    }

    // Shoot weapon and trigger cooldown
    public void ShootWeapon()
    {
        isWeaponOnCooldown = true;
        currentWeaponCooldown = weaponCooldown;
        weaponCooldownSlider.gameObject.SetActive(true); // Show the weapon cooldown slider
    }

    // Update scrap count when collecting scrap
    public void CollectScrap(int amount)
    {
        scrapCount += amount;
        UpdateScrapCountUI();
    }

    // Perform drone attack (placeholder logic)
    public void PerformDroneAttack()
    {
        if (droneAttackObject != null)
        {
            droneAttackObject.SetActive(true); // Activate or trigger the drone attack
            droneReady = false;
            UpdateDroneAttackUI();
            StartCoroutine(ResetDroneAttack());
        }
        else
        {
            Debug.LogWarning("Drone attack object not assigned!");
        }
    }

    IEnumerator ResetDroneAttack()
    {
        yield return new WaitForSeconds(10f); // Cooldown for drone attack
        droneReady = true;
        UpdateDroneAttackUI();
    }

    // Update drone attack UI
    void UpdateDroneAttackUI()
    {
        if (droneAttackText != null)
            droneAttackText.text = "Drone: " + (droneReady ? "Ready" : "On Cooldown");
        else
            Debug.LogWarning("Drone Attack Text is not assigned!");
    }

    // Update weapon UI
    void UpdateWeaponUI()
    {
        if (weaponText != null)
            weaponText.text = "Weapon: " + currentWeapon;
        else
            Debug.LogWarning("Weapon Text is not assigned!");
    }

    // Apply pickups
    public void ApplyDashCountPickup(int value)
    {
        currentDodges += value;
        UpdateDodgeCountUI();
    }

    public void ApplyDamagePickup(float value)
    {
        Debug.Log($"Player damage increased by {value}");
    }
}
