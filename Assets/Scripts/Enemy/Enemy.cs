using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameObject player;
    protected Health health;
    protected TempoHandler tempoHandler;
    protected readonly string enemyTag = "Enemy";

    
    protected void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tempoHandler = GameObject.FindGameObjectWithTag("TempoHandler").GetComponent<TempoHandler>();
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
