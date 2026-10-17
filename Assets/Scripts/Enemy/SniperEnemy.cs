using System.Collections;
using System;
using UnityEngine;

public class SniperEnemy : Enemy, IAttack
{
    [SerializeField] private float lockInTime;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackDamage;

    private Vector3 playerDirection;
    private bool isLockingOn;

    private void Start()
    {
        Attack();
    }
    private IEnumerator LockOnPlayer()
    {
        isLockingOn = true;
        yield return new WaitForSeconds(lockInTime);
        player.GetComponent<Health>().DealDamage(attackDamage);
        isLockingOn = false;
    }
    protected override void Update()
    {
        playerDirection = player.transform.position - transform.position;
    }
    public void Attack()
    {
        StartCoroutine(LockOnPlayer());
    }
    public Vector3 ReturnPlayerDirection()
    {
        return playerDirection;
    }
    public bool IsLockingOn() { 
        return isLockingOn;
    }
}
