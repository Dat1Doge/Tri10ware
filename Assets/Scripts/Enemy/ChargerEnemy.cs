using System.Collections;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

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

    IEnumerator ChargeAttack()
    {
        for (int i = 0; i < dashCount + 1; i++)
        {
            StartCoroutine(DashAttack());

            yield return new WaitForSeconds(timeBetweenDashes);
        }
    }
    protected override void Update()
    {
        playerDirection = player.transform.position - transform.position;

    }
    public void Attack()
    {
        StartCoroutine(ChargeAttack());
    }
    private IEnumerator DashAttack()
    {
        isDashing = true;
        rb.AddForce(playerDirection * dashForce);
        yield return new WaitForSeconds(dashDuration);
        rb.linearVelocity = Vector2.zero;
        isDashing = false;
        
        
        
    }
}
