using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public enum PickupType { Health, Damage, /*DashCount*/ }
    public PickupType type;  
    public float value;

    // This method triggers when something enters the collider (in this case, the player)
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                // Apply the pickup effect to the player
                ApplyPickup(player);

                // Debug message to show which type of pickup was collected
                Debug.Log($"Collected: {type} | Value: {value}");

                // Destroy the pickup after it's collected
                Destroy(gameObject);
            }
        }
    }

    // Apply the effect of the pickup
    void ApplyPickup(PlayerMovement player)
    {
        Health playerHealth = player.GetComponent<Health>();
        HUDManager hudManager = FindObjectOfType<HUDManager>();  // Get the HUDManager to update UI

        switch (type)
        {
            case PickupType.Health:
                if (playerHealth != null) 
                {
                    playerHealth.Heal(value);  // Heal player using Health script
                    // No HUD update needed for health
                }
                break;

            case PickupType.Damage:
                player.IncreaseDamage(value);  // Increase player's damage
                hudManager.ApplyDamagePickup(value);  // Update HUD for damage
                break;

            /*case PickupType.DashCount:
                player.IncreaseDashCount((int)value);  // Increase player's dash count
                hudManager.ApplyDashCountPickup((int)value);  // Update HUD for dash count
                break;*/
        }
    }
}
