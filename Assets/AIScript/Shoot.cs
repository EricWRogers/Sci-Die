using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Bullet;
    public float bulletSpeed = 10f;
    public Transform target;
    Vector2 Direction;
    public float fireRate = 1f;
    float nextFire;

    void Update()
    {
        Vector2 targetpos = target.position;
        Direction = targetpos - (Vector2)transform.position;

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();
            Debug.Log("shoot");
        }
    }
    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, FirePoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * bulletSpeed);
    }
}
