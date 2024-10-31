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
    public float attackDmg;
    public float circleAttackRange;
    public Vector2 squareAttackRange;

    public float scythTime;
    public bool scythAttacking;
    public float currentAttackTime = 0;
    public string animTrigger;
    [HideInInspector] public float attackNext;
    private float m_angle;


    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)&& attackNext < Time.time)
        {
            attackNext = Time.time + attackCooldown;
            scythAttacking = true;
            //Invoke(nameof(ScissorAttack), .5f);
        }

        if (scythAttacking)
        {
            currentAttackTime += Time.deltaTime;

            if (scythTime > currentAttackTime)
            {
                ScythAttack();
            }
            else{
                scythAttacking = false;
                currentAttackTime = 0f;
            }
        }
        
    }   



    private void ScissorAttack()
    {
            
            
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, squareAttackRange, m_angle, enemyLayers);


            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Health>().TakeDamage(attackDmg);
            }
        
    }


    private void ScythAttack()
    {
   
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, circleAttackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(attackDmg);

        }
    }


}


