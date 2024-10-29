using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class DroneWeapon : MonoBehaviour
{

    public Vector2 mousPos;
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


    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OnAttackCircle();
        }
    }   

    public void OnAttackCircle()
    {
        if ( Time.time >= attackNext)
        {
            mousPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            attackNext = Time.time + attackCooldown;
            attackAnim.SetTrigger(animTrigger);
        

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(mousPos, circleAttackRange, enemyLayers);

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


            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Health>().TakeDamage(attackDmg);
            }
        }
    }


}


