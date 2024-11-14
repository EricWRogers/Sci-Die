using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScrapPickup : MonoBehaviour
{
    public int value;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("scrap"))
        {
            Destroy(other);
            
            
        }
    }

}
