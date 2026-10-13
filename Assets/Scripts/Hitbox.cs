using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private LayerMask projectileLayerMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == projectileLayerMask)
        {
            Projectile projectile = collision.GetComponent<Projectile>();

            //projectile and health logic here

            Destroy(collision.gameObject);
        }
    }

}
