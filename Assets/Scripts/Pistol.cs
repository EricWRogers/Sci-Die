using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponManager
{
    public float speed = 20.0f;

    void Awake(){
        timeLeft = 3.0f;
    }
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        timeLeft = timeLeft - Time.deltaTime;
        if(timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }
}
