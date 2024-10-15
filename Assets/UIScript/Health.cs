using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 10;
    HealthBar healthBar;
     public UnityEvent outOfHealth;
    
    void Start()
    {
        healthBar = GetComponent<HealthBar>();
        currentHealth = maxHealth;

    }


    public void TakeDamage(float damage)
    {

          currentHealth -= damage;
          //healthBar.UpdateHealthbar(currentHealth, maxHealth);
          if (currentHealth <= 0)
          {
               outOfHealth.Invoke();
          }
    
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           // TakeDamage(1.0f);

        }
    }
}
