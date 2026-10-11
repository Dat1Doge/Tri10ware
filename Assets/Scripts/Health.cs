using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float health;

    public Action OnDeath;

    public void SetHealth(float newhealth)
    {
        health = newhealth;
    }

    public float GetHealth(){
        return health;
    }
    
    public void DealDamage(int damage) {
        health = Mathf.Max(0,health-damage);
        if(health == 0){
            OnDeath?.Invoke();
        }
    }
}
