using System.Collections;
using UnityEngine;

public class GroundSlamEffect : MonoBehaviour
{
    [SerializeField] private ChargerEnemy chargerEnemy;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float animationTime = 0.5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        chargerEnemy.OnHeadSmash += InitiateHitEffect;
    }
    private IEnumerator StartSlamEffect()
    {
        spriteRenderer.enabled = true;
        animator.SetTrigger("HeadSmash");
        yield return new WaitForSeconds(animationTime);
        spriteRenderer.enabled = false;
    }
    private void InitiateHitEffect()
    {
        StartCoroutine(StartSlamEffect());
       
    }
}
