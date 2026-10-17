using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected float projectileDamage;
    [SerializeField] protected float projectileLifespan;
    protected string senderTag;
    protected Rigidbody2D rb;

    #region Getters
    public float GetProjectileSpeed() { 
        return projectileSpeed;
    }
    public float GetProjectileDamage() {
        return projectileDamage;
    }
    public float GetProjectileLifespan() {
        return projectileLifespan;
    }
    #endregion

    protected virtual void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Fire(Vector2 direction, string tag) {
        rb.linearVelocity = direction.normalized*projectileSpeed;
        Destroy(this.gameObject,projectileLifespan);
        senderTag = tag;
    }

    protected virtual void Hit(Collider2D other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy"){
            Health health = other.GetComponent<Health>();
            health.DealDamage(projectileDamage);
        }
        Destroy(this.gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag!=senderTag && senderTag != null) {
            Hit(other);
        }
    }

    protected virtual void OnDestroy(){

    }
}
