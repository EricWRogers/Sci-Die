using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShopTriggerCollider : MonoBehaviour
{
    public GameObject shop;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shop.SetActive(true);
        }
        
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shop.SetActive(false);
        }
    }
}
