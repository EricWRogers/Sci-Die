using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    // HUD UI Elements
    public Text dodgeCountText;        // Text for displaying dodge count
    public Slider chargeSlider;         // Slider for heavy gun charge
    public Text inventoryText;          // Text for displaying inventory items

    // Health and Dodge Properties
    private int maxDodges = 3;         // Maximum number of dodges
    private int currentDodges;          // Current dodge count
    private float chargeTime = 3f;      // Charge time for heavy gun
    private float currentChargeTime;     // Current charge time
    private List<string> items = new List<string>(); // Inventory items

    void Start()
    {
        currentDodges = maxDodges;
        chargeSlider.gameObject.SetActive(false); // Hide charge slider initially
        UpdateDodgeCountUI();
        UpdateInventoryUI();
    }

    void Update()
    {
        // Dodge logic
        if (Input.GetKeyDown(KeyCode.Space) && currentDodges > 0) // Press 'Space' to dodge
        {
            PerformDodge();
        }

        // Charge heavy gun
        if (Input.GetKeyDown(KeyCode.E)) // Press 'E' to start charging
        {
            StartCoroutine(ChargeGun());
        }

        // Add item to inventory for testing
        if (Input.GetKeyDown(KeyCode.I)) // Press 'I' to add an item
        {
            AddItem("Health Potion");
        }
    }

    // Update dodge count UI
    void UpdateDodgeCountUI()
    {
        dodgeCountText.text = "Dodges: " + currentDodges;
    }

    // Perform dodge and update count
    void PerformDodge()
    {
        currentDodges--;
        UpdateDodgeCountUI();
    }

    // Charge gun method
    IEnumerator ChargeGun()
    {
        currentChargeTime = 0;
        chargeSlider.gameObject.SetActive(true); // Show the charge slider

        while (currentChargeTime < chargeTime)
        {
            currentChargeTime += Time.deltaTime;
            chargeSlider.value = currentChargeTime / chargeTime; // Update slider value
            yield return null;
        }

        chargeSlider.gameObject.SetActive(false); // Hide the slider after charging
    }

    // Add an item to the inventory
    public void AddItem(string item)
    {
        items.Add(item);
        UpdateInventoryUI();
    }

    // Update inventory UI
    void UpdateInventoryUI()
    {
        inventoryText.text = "Inventory: " + string.Join(", ", items);
    }
}
