using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileDamage;
    [SerializeField] private float projectileLifespan;
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
}
