using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPickup : MonoBehaviour
{
    bool playerColliding = false;
    void Update()
    {
        if(playerColliding && (Input.GetKeyDown(KeyCode.E))){
            Destroy(gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D other){
        playerColliding = true;
    }
    
}
