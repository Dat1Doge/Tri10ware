using UnityEngine;

public class DragonFluteAnimation : MonoBehaviour
{
    private AreaEnemy areaEnemy;
    private Animator enemyAreaAnimator;
    void Start()
    {
        enemyAreaAnimator = GetComponent<Animator>();
        areaEnemy = GetComponent<AreaEnemy>();
        areaEnemy.OnAttack += TriggerAttackAnimation;
    }

    private void TriggerAttackAnimation()
    {
        enemyAreaAnimator.SetTrigger("isAttacking");
    }
}
