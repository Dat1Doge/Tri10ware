using System.Collections;
using System;
using UnityEngine;

public class SniperEnemy : Enemy, IAttack
{
    [Header("Sniper Attack Settings")]
    [SerializeField] private float lockInTime;
    [SerializeField] private GameObject projectile;
    [Header("General Settings")]
    [SerializeField] private float attackCooldown;
    

    private Vector3 playerDirection;
    private bool isLockingOn;
    private bool canAttack;
    private void Start()
    {
        Attack();
    }
    private IEnumerator LockOnPlayer()
    {
        isLockingOn = true;
        yield return new WaitForSeconds(lockInTime);
        GameObject newProjectile = Instantiate(projectile.gameObject,transform.position,transform.rotation);
        newProjectile.GetComponent<Projectile>().Fire(GetPlayerDirection(), "Enemy");
        isLockingOn = false;
 
        StartCoroutine(HandleAttackCooldown());
    }
    private IEnumerator HandleAttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    protected override void Update()
    {
        playerDirection = player.transform.position - transform.position;

        if (canAttack)
        {
            Attack();
            canAttack = false;
        }
        
    }
    public void Attack()
    {
        StartCoroutine(LockOnPlayer());
    }
    public Vector3 GetPlayerDirection()
    {
        return playerDirection;
    }
    public bool IsLockingOn() { 
        return isLockingOn;
    }
}
