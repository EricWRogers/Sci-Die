using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 6; // Max health set to 6 for 3 hearts
    HealthCounter healthCounter;
    public UnityEvent outOfHealth;

    void Start()
    {
        healthCounter = GetComponent<HealthCounter>();
        currentHealth = maxHealth; // Start with full health (3 hearts)
        healthCounter.UpdateHealthCounter(currentHealth); // Initialize hearts
    }

    void Update()
    {
        // Test: Press 'F' to take 1 damage
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(1f); // Take 1 damage per press
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // Prevent health from going below 0
        healthCounter.UpdateHealthCounter(currentHealth); // Update hearts
        if (currentHealth <= 0)
        {
            outOfHealth.Invoke(); // Trigger "out of health" event if health is 0
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth); // Heal but don't exceed max health
        healthCounter.UpdateHealthCounter(currentHealth); // Update hearts
    }
}
