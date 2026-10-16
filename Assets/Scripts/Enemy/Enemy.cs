using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameObject player;
    protected Health health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = GetComponent<Health>();
        health.OnDeath += Die;
    }

    protected void Die() 
    {
        Destroy(gameObject);
    }

    protected void Update()
    {

    }
}
