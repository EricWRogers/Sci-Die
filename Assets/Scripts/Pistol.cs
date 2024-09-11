using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float speed = 20.0f;

    public float timeLeft = 3.0f;
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        timeLeft = timeLeft - Time.deltaTime;
        if(timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }
}
