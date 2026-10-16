using UnityEngine;
using System.Collections.Generic;

public class EnergyBall : Projectile
{
    [Header("Explosion Settings")]
    [SerializeField] private float explosionRadius;
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private float explosionVFXDuration;
    
    [SerializeField] private ContactFilter2D contactFilter;

    protected override void Hit(Collider2D col) {
        Destroy(this.gameObject);
    }

    protected override void OnDestroy(){
        Destroy(Instantiate(explosionVFX,transform.position,transform.rotation),explosionVFXDuration);

        List<Collider2D> colliders = new List<Collider2D>();
        Physics2D.OverlapCircle(transform.position,explosionRadius,contactFilter,colliders);
        foreach(Collider2D col in colliders){
            if(col.tag != senderTag){
                col.GetComponent<Health>().DealDamage(projectileDamage);
            }
        }
    }
}
