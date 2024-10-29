using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;             
    private float currentHealth;               

    [Header("UI Elements")]
    public Slider healthSlider;                

    void Start()
    {
        currentHealth = maxHealth;             
        UpdateHealthSlider();                  
    }

    // Method to take damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;               
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
        UpdateHealthSlider();                  

        if (currentHealth <= 0)
        {
            Die();                             
        }
    }

    // Method to update the health slider
    private void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth; 
        }
        else
        {
            Debug.LogWarning("Health slider is not assigned!");
        }
    }

    // Method to handle enemy death
    private void Die()
    {
        // Destroy or disable the enemy game object
        Destroy(gameObject);
        
    }
}
