using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 10;
    HealthBar healthBar;
    
    
    void Start()
    {
        healthBar = GetComponent<HealthBar>();
        currentHealth = maxHealth;

    }


    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealthbar(currentHealth, maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1.0f);

        }
    }
}
