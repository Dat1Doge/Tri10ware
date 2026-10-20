using System.Collections;
using UnityEngine;


public class ChargerEnemy : Enemy, IAttack
{
    [Header("Dash Attack Settings")]
    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;
    [SerializeField] private float timeBetweenDashes;
    [SerializeField] private int dashCount;
    [Header("General Settings")]
    [SerializeField] private float attackCooldown;

    private Vector3 playerDirection;
    private bool isDashing;
    private bool canAttack;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Attack();
    } 
    private IEnumerator DashAttack()
    {
        isDashing = true;
        rb.AddForce(playerDirection * dashForce);
        yield return new WaitForSeconds(dashDuration);
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
    }

    public void Attack()
    {
        StartCoroutine(ChargeAttack());
    }
   
}
