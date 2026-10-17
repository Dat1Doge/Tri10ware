using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameObject player;
    protected Health health;

    
    protected void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = GetComponent<Health>();
        health.OnDeath += Die;
    }

    protected void Die() 
    {
        Destroy(gameObject);
    }
    protected virtual void Update()
    {
        
    }
}
