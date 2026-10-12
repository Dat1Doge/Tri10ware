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
    private TempoHandler tempoHandler;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tempoHandler = GameObject.FindGameObjectWithTag("TempoHandler").GetComponent<TempoHandler>();

        inputManager.OnDashButtonPressed += Dash;
    }

    private IEnumerator dashSequence(){
        float bpmMulti = tempoHandler.GetBPMmulti();

        dashing = true;
        canDash = false;
        rb.AddForce(inputManager.GetMovementVector() * dashForce * bpmMulti);

        yield return new WaitForSeconds(dashDuration/bpmMulti);
        dashing = false;

        yield return new WaitForSeconds(dashCooldown/bpmMulti);
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
            rb.linearVelocity = inputManager.GetMovementVector() * speed * tempoHandler.GetBPMmulti();
        }
    }
}
