using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f;

    public float timeLeft = 3.0f;
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        timeLeft = timeLeft - Time.deltaTime;
        /*if(transform.root!=transform){
            Destroy(gameObject.parent);
        } The parent of the shotgun bullets is left behind currently when the bullets get deleted.*/ 
        if(timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }
}
