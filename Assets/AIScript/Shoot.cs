using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int attackDis;
    public float pistolFireRate = 1f;
    public float machineGunFireRate = 1f;
    public float rotateSpeed;
    public float shotgunFireRate = 1f;
    public GameObject topFirePoint;
    public GameObject middleFirePoint;
    public GameObject bottomFirePoint;

    public GameObject Bullet;
    public ShootPattern enemyGun = ShootPattern.Pistol;

    private Vector3 m_dir;
    private float m_nextFire;
    private GameObject m_target;
    private EnemyAI m_enemyAI;

    public enum ShootPattern {MachineGun, Shotgun, Pistol};

    private void Start()
    {
        m_target = GameObject.FindGameObjectWithTag("Player");
        m_enemyAI = gameObject.GetComponent<EnemyAI>();
    }

    void FixedUpdate()
    {
        m_dir = m_target.transform.position - transform.position;
        float angle = (Mathf.Atan2(m_dir.y, m_dir.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Debug.Log("" + m_dir);
        if(enemyGun != ShootPattern.Shotgun)
        {
            topFirePoint.SetActive(false);
            bottomFirePoint.SetActive(false);
        }

        float distance = Vector3.Distance(transform.position, m_target.transform.position);
        if (distance <= attackDis)
        {
            shoot();
        }
        else
        {
            m_enemyAI.speed = m_enemyAI.maxSpeed;
        }

            //shoot();
    }
    void shoot()
    {
        if(enemyGun == ShootPattern.Pistol)
        {
            m_enemyAI.speed = 0;
            if (Time.time > m_nextFire)
            {
                m_nextFire = Time.time + pistolFireRate;
                GameObject BulletIns = Instantiate(Bullet, middleFirePoint.transform.position, middleFirePoint.transform.rotation);
            }
        }
        if (enemyGun == ShootPattern.MachineGun)
        {
            m_enemyAI.speed = 0;
            float angle = Mathf.PingPong(Time.time * rotateSpeed, 90f) - 45f;
            float curAngle = (Mathf.Atan2(m_dir.y, m_dir.x) * Mathf.Rad2Deg);
            transform.rotation = Quaternion.AngleAxis(angle + curAngle, Vector3.forward);

            if (Time.time > m_nextFire)
            {
                m_nextFire = Time.time + machineGunFireRate;
                GameObject BulletIns = Instantiate(Bullet, middleFirePoint.transform.position, middleFirePoint.transform.rotation);
            }
        }
        if (enemyGun == ShootPattern.Shotgun)
        {
            m_enemyAI.speed = 0;
            if (Time.time > m_nextFire)
            {
                m_nextFire = Time.time + shotgunFireRate;
                GameObject BulletInsMid = Instantiate(Bullet, middleFirePoint.transform.position, middleFirePoint.transform.rotation);
                GameObject BulletInsTop = Instantiate(Bullet, topFirePoint.transform.position, topFirePoint.transform.rotation);
                GameObject BulletInsBot = Instantiate(Bullet, bottomFirePoint.transform.position, bottomFirePoint.transform.rotation);
            }
        }
    }
}
