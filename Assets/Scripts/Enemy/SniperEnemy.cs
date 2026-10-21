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

    [Header("Audio")]
    private SoundEffectPlayer sfxPlayer;
    [SerializeField] private SoundEffect shoot;

    private Vector3 playerDirection;
    private Vector3 adjustedPlayerDirection;
    private Rigidbody2D playerRb;
    private bool isLockingOn;
    private bool canAttack;
    private Animator animator;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Attack();
        sfxPlayer = GetComponent<SoundEffectPlayer>();
    }

    private IEnumerator LockOnPlayer()
    {
        isLockingOn = true;
        animator.SetBool("isAttacking", isLockingOn);
        yield return new WaitForSeconds(lockInTime);
        sfxPlayer.PlaySound(shoot);
        GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
        newProjectile.GetComponent<Projectile>().Fire(GetPlayerDirection(), enemyTag);
        isLockingOn = false;
        animator.SetBool("isAttacking", isLockingOn);
        StartCoroutine(HandleAttackCooldown());
    }

    private IEnumerator HandleAttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    protected void FixedUpdate()
    {
        Vector2 playerVel = playerRb.linearVelocity;
        float playerSpd = playerVel.magnitude;

        playerDirection = player.transform.position - transform.position;
        adjustedPlayerDirection = playerDirection + new Vector3(playerVel.x, playerVel.y, 0);

        float bulletTravelTime = adjustedPlayerDirection.magnitude / projectile.GetComponent<Projectile>().GetProjectileSpeed();
        float playerMovementMagnitude = bulletTravelTime * playerSpd;

        Vector2 normalizedPlayerVel = playerVel.normalized;
        adjustedPlayerDirection = playerDirection + playerMovementMagnitude * new Vector3(normalizedPlayerVel.x, normalizedPlayerVel.y, 0);

        float directionInterval = 0.5f;

        if (GetPlayerDirection().x > directionInterval)
        {
            this.transform.rotation = Quaternion.Euler(0, -180, 0);
            animator.SetFloat("MoveDirectionX", 1);
        }
        else if (GetPlayerDirection().x < -directionInterval)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetFloat("MoveDirectionX", -1);
        }
        else if (GetPlayerDirection().y > directionInterval)
        {
            animator.SetFloat("MoveDirectionY", 1);
        }
        else if (GetPlayerDirection().y < -directionInterval)
        {
            animator.SetFloat("MoveDirectionY", -1);
        }
        


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
        return adjustedPlayerDirection;
    }

    public bool IsLockingOn()
    {
        return isLockingOn;
    }
}
