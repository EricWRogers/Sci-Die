using System.Collections;
using UnityEngine;
using UnityEngine.UI;  // If you're using a UI slider to show health

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;  // maximum health for the enemy
    public float currentHealth;    // Current health of the enemy
    public Slider healthSlider;     // Reference to a slider
    public GameObject enemyDeathEffect; // Optional: Add a visual effect (like an explosion) when the enemy dies

    // Optional: This event will be triggered when the enemy dies
    public UnityEngine.Events.UnityEvent onDeath;

    private void Start()
    {
        // Initialize the health to the max health at the start of the game
        currentHealth = maxHealth;

        // Update the health slider if it's assigned
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    // Method to handle taking damage from bullets
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;  // Subtract the damage from the current health

        // Clamp health to make sure it doesn't go below 0
        currentHealth = Mathf.Max(currentHealth, 0f);

        // Update the health slider UI if assigned
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        // Check if the enemy's health has reached 0
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to handle enemy death
    private void Die()
    {
        // Optionally, trigger a death effect (e.g., explosion or particle effect)
        if (enemyDeathEffect != null)
        {
            Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
        }

        // Optionally trigger the onDeath event if you want to do something else (e.g., score update)
        onDeath.Invoke();

        // Destroy the enemy game object after a short delay (optional)
        Destroy(gameObject);
    }
}
