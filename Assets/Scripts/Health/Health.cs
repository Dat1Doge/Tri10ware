using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject damageText;
    private float health;

    public Action OnDeath;
    public Action OnHealthChanged;

    void Start() {
        SetHealth(maxHealth);
    }

    public void SetHealth(float newhealth)
    {
        health = Mathf.Clamp(newhealth,0,maxHealth);
        OnHealthChanged?.Invoke();
    }

    public float GetMaxHealth() {
        return maxHealth;
    }

    public float GetCurrentHealth(){
        return health;
    }
    
    public void Heal(float amount) {
        SetHealth(health+amount);
    }

    public void DealDamage(float damage) {
        Instantiate(damageText,transform.position,transform.rotation).GetComponent<DamageText>().ChangeText(damage);
        SetHealth(health-damage);
        OnHealthChanged?.Invoke();
        if(health == 0){
            OnDeath?.Invoke();
            Debug.Log(gameObject.name + "killed!");
        }
    }
}
