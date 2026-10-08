using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = (new Vector2(x,y)).normalized*speed;
    }
}
