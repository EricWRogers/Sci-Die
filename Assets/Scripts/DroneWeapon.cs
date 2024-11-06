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
            
            Invoke(nameof(ScythAttack), 2f);
            scythAttacking = true;
        }

        if (scythAttacking)
        {
                ScythAttack();
                
                Debug.Log("Calling ScythAttack");
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

    private void ScythAttacking()
    {
        scythAttacking = false;
    }

private void SpearAttack(){
                Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, squareAttackRange, m_angle, enemyLayers);


            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Health>().TakeDamage(attackDmg);
            }
}

}


