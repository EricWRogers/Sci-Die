using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPickup : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other){
        if(Input.GetKeyDown(KeyCode.E)){
            Debug.Log("Pickup");
            Destroy(gameObject);
        }
    }
}
