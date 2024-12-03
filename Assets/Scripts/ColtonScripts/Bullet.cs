using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f;
    public float damage = 1;

    public float timeLeft = 3.0f;
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        timeLeft = timeLeft - Time.deltaTime;
        if(timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            Debug.Log("Hit Enemy");
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == ("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
