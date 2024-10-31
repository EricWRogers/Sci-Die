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
    
    public string animTrigger;
    [HideInInspector] public float attackNext;
    private float m_angle;


    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)&& attackNext < Time.time)
        {
            attackNext = Time.time + attackCooldown;
            OnAttackCircle();
            Invoke(nameof(ScissorAttack), .5f);
        }
    }   

    public void OnAttackCircle()
    {
        if ( Time.time >= attackNext)
        {
            mousPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        }
    }
    public void OnAttackSquare()
    {

        if (Input.GetKeyDown(attackKey) && Time.time >= attackNext)
        {


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


