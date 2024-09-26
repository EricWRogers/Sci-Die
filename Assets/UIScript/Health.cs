using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 10;  // Set initial max health
    HealthBar healthBar;
    public UnityEvent outOfHealth;

    void Start()
    {
        healthBar = GetComponent<HealthBar>();
        currentHealth = maxHealth;  // Initialize current health to max
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealthbar(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            outOfHealth.Invoke();  // Trigger event if health is zero
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);  // Heal but don't exceed max health
        healthBar.UpdateHealthbar(currentHealth, maxHealth);           // Update the health bar
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Example damage for testing
            // TakeDamage(1.0f);
        }
    }
}
