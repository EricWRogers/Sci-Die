using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    public Image[] hearts; // UI Image components representing the hearts
    public Sprite fullHeart; // Sprite for a full heart
    public Sprite halfHeart; // Sprite for a half heart
    public Sprite emptyHeart; // Sprite for an empty heart

    public void UpdateHealthCounter(float currentHealth)
    {
        // Loop through each heart and update based on remaining health
        for (int i = 0; i < hearts.Length; i++)
        {
            if (currentHealth >= (i + 1) * 2)
            {
                hearts[i].sprite = fullHeart; // Full heart for 2 health points
            }
            else if (currentHealth >= (i * 2) + 1)
            {
                hearts[i].sprite = halfHeart; // Half heart for 1 health point
            }
            else
            {
                hearts[i].sprite = emptyHeart; // Empty heart for 0 health points
            }
        }
    }
}
