using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileDamage;
    [SerializeField] private float projectileLifespan;
    public GameObject sender;
    private Rigidbody2D rb;

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

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 direction) {
        rb.linearVelocity = direction.normalized*projectileSpeed;
        Destroy(this.gameObject,projectileLifespan);
    }

    private void OnTriggerEnter2d(Collider2D other){
        if((other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy") && other.gameObject.tag!=sender.gameObject.tag){
            Health health = other.GetComponent<Health>();
            health.DealDamage(projectileDamage);
        }
    }
}
