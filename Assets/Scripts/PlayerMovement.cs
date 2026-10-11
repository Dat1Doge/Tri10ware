using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [Header("Dash Settings")]
    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    [SerializeField] private InputManager inputManager;

    private bool dashing = false;
    private bool canDash = true;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        inputManager.OnDashButtonPressed += Dash;
    }

    private IEnumerator dashSequence(){
        dashing = true;
        canDash = false;
        rb.AddForce(inputManager.GetMovementVector() * dashForce);

        yield return new WaitForSeconds(dashDuration);
        dashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void Dash()
    {
        if(canDash){
            StartCoroutine("dashSequence");
        }
    }

    void FixedUpdate()
    {
        if(!dashing){
            rb.linearVelocity = inputManager.GetMovementVector() * speed;
        }
    }
}
