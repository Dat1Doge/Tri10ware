using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnemy : Enemy, IAttack
{
    [Header("Attack Settings")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject projectile;

    [SerializeField] List<Transform> shotPoints;
    [Header("Roaming Settings")]
    [SerializeField] private float roamTime;
    [SerializeField] private float roamSpeed;
    [SerializeField] private float roamDelay;

    private readonly float randomRoamMax = -0.5f;
    private readonly float randomRoamMin = 0.5f;
    private Rigidbody2D rigidBody;

    private bool canAttack;
    private bool canRoam;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Attack();
    }

    protected override void Update()
    {
        if (canAttack)
        {
            Attack();
            canAttack = false;
        }
        if (canRoam)
        {
            StartCoroutine(Roam());
            canRoam = false;
        }
    }

    public void Attack()
    {
        StartCoroutine(RadialAttack());
    }
    private IEnumerator RadialAttack()
    {
        foreach (Transform t in shotPoints)
        {
            Vector3 shotDirection = t.position - transform.position;

            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
            newProjectile.GetComponent<Projectile>().Fire(shotDirection, enemyTag);
        }
        StartCoroutine(HandleAttackCooldown());

        yield return new WaitForSeconds(roamDelay);
        canRoam = true;
    }
    private IEnumerator Roam()
    {
        Vector2 roamDirection = GetRandomRoamDirection();
        rigidBody.linearVelocity = roamDirection * roamSpeed;
        yield return new WaitForSeconds(roamTime);
        
        rigidBody.linearVelocity = Vector2.zero;
    }
    private IEnumerator HandleAttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public Vector2 GetRandomRoamDirection()
    {
        float randomRoamDirectionX = UnityEngine.Random.Range(randomRoamMin, randomRoamMax);
        float randomRoamDirectionY = UnityEngine.Random.Range(randomRoamMin,randomRoamMax);
        Vector2 roamDirection = new Vector2(randomRoamDirectionX,randomRoamDirectionY);

        return roamDirection;
    }
}
