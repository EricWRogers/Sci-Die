using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Bullet;
    public Transform target;
    Vector2 dir;
    public float fireRate = 1f;
    float nextFire;

    void FixedUpdate()
    {
        dir = target.position - transform.position;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();
            Debug.Log("shoot");
        }
    }
    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
    }
}
