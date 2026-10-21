using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.U2D.Physics.PhysicsShape;


public class ChargerEnemy : Enemy, IAttack
{
    [Header("Dash Attack Settings")]
    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;
    [SerializeField] private float timeBetweenDashes;
    [SerializeField] private int dashCount;
    [SerializeField] private float dashAttackDamage;
    [Header("Circle Cast Settings")]
    [SerializeField] private float circleRadius;
    [SerializeField] private ContactFilter2D contactFilter;
    [Header("General Settings")]
    [SerializeField] private float attackCooldown;

    private Animator animator;
    private Vector3 playerDirection;
    private bool isDashing;
    private bool canAttack;
    private bool dashHitAlready;
    private float smashAndRestDelay = 1.0f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Attack();
    } 
    private IEnumerator DashAttack()
    {
        isDashing = true;
        

        dashHitAlready = false;

        rb.AddForce(playerDirection * dashForce);
        animator.SetTrigger("HeadSmash");
        yield return new WaitForSeconds(dashDuration);
        animator.SetTrigger("Rest");

        rb.linearVelocity = Vector2.zero;
        isDashing = false;
    }
    private IEnumerator ChargeAttack()
    {
        canAttack = false;
        for (int i = 0; i < dashCount + 1; i++)
        {
            StartCoroutine(DashAttack());

            yield return new WaitForSeconds(timeBetweenDashes);
        }

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
        playerDirection = (player.transform.position - transform.position).normalized;

        if (canAttack) { Attack(); }

        if (isDashing)
        {
            List<Collider2D> colliders = new List<Collider2D>();
            Physics2D.OverlapCircle(transform.position, circleRadius, contactFilter, colliders);
            foreach(Collider2D collider in colliders)
            {
                if(collider.gameObject.tag == "Player" && !dashHitAlready)
                {
                    Health health = collider.gameObject.GetComponent<Health>();
                    health.DealDamage(dashAttackDamage);
                    dashHitAlready = true;
                } 
            }
        }
    }

    public void Attack()
    {
        StartCoroutine(ChargeAttack());
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, circleRadius);
    }
    */

}
