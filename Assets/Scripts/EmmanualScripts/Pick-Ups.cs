using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public enum PickupType { Health, Damage, DashCount }
    public PickupType type;  
    public float value;      

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                ApplyPickup(player);
                Destroy(gameObject);
            }
        }
    }

    void ApplyPickup(PlayerMovement player)
    {
        Health playerHealth = player.GetComponent<Health>();

        switch (type)
        {
            case PickupType.Health:
                if (playerHealth != null) 
                {
                    playerHealth.Heal(value);
                }
                break;

            case PickupType.Damage:
                player.damage += value;  
                break;

            case PickupType.DashCount:
                player.dashCount += (int)value;  
                break;
        }
    }
}
