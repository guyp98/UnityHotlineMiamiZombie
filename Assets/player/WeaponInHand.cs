using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInHand : MonoBehaviour
{

    public WeaponItem weaponInHand;
    public Animator animator;

    public Transform attackPoint;
    private float attackRange ;
    public LayerMask enemyLayer;
    private int damge;

    public void PutWeaponInHand(WeaponItem WeaponToPut)
    {
        weaponInHand = WeaponToPut;
        attackRange = weaponInHand.range;
        damge = weaponInHand.damge;
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    public void Attack()
    {
        //animator.SetTrigger("");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);


        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit "+ enemy.name);
            enemy.GetComponent<EnemyHealth>().SubHealth(damge);
        }
            
            
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint== null) { return; }
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }

}
