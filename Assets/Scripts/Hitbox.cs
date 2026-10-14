using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private int layerMaskNumber;

    private void Start()
    {
       health = gameObject.GetComponent<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == layerMaskNumber)
        {
            Projectile projectile = collision.GetComponent<Projectile>();

            health.DealDamage((int)projectile.GetProjectileDamage());
            Debug.Log(collision.gameObject.name + " hit " + health.gameObject.name);
            Destroy(collision.gameObject);
        }
            
    }

}
