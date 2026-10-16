using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileDamage;
    [SerializeField] private float projectileLifespan;
    private string senderTag;
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

    public void Fire(Vector2 direction, string tag) {
        rb.linearVelocity = direction.normalized*projectileSpeed;
        Destroy(this.gameObject,projectileLifespan);
        senderTag = tag;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag!=senderTag){
            if((other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")){
                Health health = other.GetComponent<Health>();
                health.DealDamage(projectileDamage);
            }
            Destroy(this.gameObject);
        }
    }
}
