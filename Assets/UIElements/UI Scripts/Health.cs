using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 6; // Max health set to 6 for 3 hearts
    //HealthCounter healthCounter;
    public UnityEvent outOfHealth;

    void Start()
    {
        //healthCounter = GetComponent<HealthCounter>();
        currentHealth = maxHealth; // Start with full health (3 hearts)
        //healthCounter.UpdateHealthCounter(currentHealth); // Initialize hearts
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // Prevent health from going below 0
        //healthCounter.UpdateHealthCounter(currentHealth); // Update hearts
        if (currentHealth <= 0)
        {
            HandleOutOfHealth();
        }
    }

    private void HandleOutOfHealth()
    {
        if (CompareTag("Player"))
        {
            outOfHealth.Invoke(); // Player's out-of-health triggers lose condition
        }
        else if (CompareTag("Enemy"))
        {
            gameObject.SetActive(false); // Deactivate enemy on defeat
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth); // Heal but don't exceed max health
        //healthCounter.UpdateHealthCounter(currentHealth); // Update hearts
    }
}
