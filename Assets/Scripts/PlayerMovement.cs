using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float dashForce;
    [SerializeField] private InputManager inputManager;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        inputManager.OnDashButtonPressed += Dash;
    }

    private void Dash()
    {

    }

    void FixedUpdate()
    {
        // Old Input System
        /* float x = Input.GetAxisRaw("Horizontal");
         float y = Input.GetAxisRaw("Vertical");
         rb.linearVelocity = (new Vector2(x,y)).normalized*speed; */

        //New Input System (you can choose which one to use)
        rb.linearVelocity = inputManager.GetMovementVector() * speed;
    }

    
}
