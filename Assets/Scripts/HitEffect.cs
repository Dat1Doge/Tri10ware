using System.Collections;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    private Health health;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] private float damageFlashTime;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        health.OnHealthChanged += DamageTaken;
    }
    private void DamageTaken()
    {
        StartCoroutine(FlashDamageEffect());
    }
    IEnumerator FlashDamageEffect()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(damageFlashTime);
        spriteRenderer.color = Color.white;
        
    }
}
