using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    // HUD UI Elements
    public TextMeshProUGUI dashCountText;
    public Slider weaponCooldownSlider;
    public TextMeshProUGUI droneAttackText;
    public TextMeshProUGUI weaponText;
    public TextMeshProUGUI scrapCountText;

    // Health and Dash Properties
    public int maxDash = 3;
    public PlayerMovement playerMovement;  // Reference to PlayerMovement script to access dash count

    // Weapon Cooldown Properties
    private float weaponCooldown = 5f;
    private float currentWeaponCooldown = 0f;
    private bool isWeaponOnCooldown = false;

    // Drone Attack and Scrap Count
    public GameObject droneAttackObject;
    public GameObject scrapObject;

    private bool droneReady = true;
    private string currentWeapon = "Pistol";
    private int scrapCount = 0;

    void Start()
    {
        if (dashCountText == null)
        {
            Debug.LogWarning("Dash Count Text is not assigned in the HUDManager!");
        }

        weaponCooldownSlider.gameObject.SetActive(false);
        UpdateDashCountUI();  // Initial update to display dash count
        UpdateDroneAttackUI();
        UpdateWeaponUI();
        UpdateScrapCountUI();
    }

    void Update()
    {
        UpdateDashCountUI();  // Regularly update dash count in the UI

        // Weapon cooldown logic
        if (isWeaponOnCooldown)
        {
            currentWeaponCooldown -= Time.deltaTime;
            weaponCooldownSlider.value = currentWeaponCooldown / weaponCooldown;

            if (currentWeaponCooldown <= 0)
            {
                isWeaponOnCooldown = false;
                currentWeaponCooldown = 0;
                weaponCooldownSlider.gameObject.SetActive(false);
            }
        }
    }

    // Update dash count UI
    public void UpdateDashCountUI()
    {
        if (playerMovement != null && dashCountText != null)
        {
            dashCountText.text = "Dash: " + playerMovement.dashCount;
        }
        else if (dashCountText == null)
        {
            Debug.LogWarning("Dash Count Text is not assigned in the HUDManager!");
        }
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
        weaponCooldownSlider.gameObject.SetActive(true);
    }

    // Update scrap count when collecting scrap
    public void CollectScrap(int amount)
    {
        scrapCount += amount;
        UpdateScrapCountUI();
    }

    // Perform drone attack
    public void PerformDroneAttack()
    {
        if (droneAttackObject != null)
        {
            droneAttackObject.SetActive(true);
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
        yield return new WaitForSeconds(10f);
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
        if (playerMovement != null)
        {
            playerMovement.IncreaseDashCount(value);
            UpdateDashCountUI();
        }
    }

    public void ApplyDamagePickup(float value)
    {
        Debug.Log($"Player damage increased by {value}");
    }

    // Toggle HUD visibility
    public void ToggleHUDVisibility()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
