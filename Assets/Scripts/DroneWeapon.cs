using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWeapon : MonoBehaviour
{
    public KeyCode attackKey;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackCooldown;
    public int attackDmg;
    public float circleAttackRange;
    public Vector2 squareAttackRange;
    public Animator attackAnim;
    public string animTrigger;
    [HideInInspector] public float attackNext;
    private float m_angle;

    public AudioSource attackSound;


    public void OnAttackCircle()
    {
        if (Input.GetKeyDown(attackKey) && Time.time >= attackNext)
        {
            attackNext = Time.time + attackCooldown;
            attackAnim.SetTrigger(animTrigger);
            attackSound.Play();

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, circleAttackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Health>().TakeDamage(attackDmg);

            }
        }
    }
    public void OnAttackSquare()
    {

        if (Input.GetKeyDown(attackKey) && Time.time >= attackNext)
        {
            attackNext = Time.time + attackCooldown;
            attackAnim.SetTrigger(animTrigger);
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, squareAttackRange, m_angle, enemyLayers);
            attackSound.Play();

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Health>().TakeDamage(attackDmg);
            }
        }
    }


}


