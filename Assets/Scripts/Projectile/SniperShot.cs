using UnityEngine;

public class SniperShot : Projectile
{
    protected override void Hit(Collider2D other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy"){
            Health health = other.GetComponent<Health>();
            health.DealDamage(projectileDamage);
        }
        else {
            Destroy(this.gameObject);
        }
    }
}
