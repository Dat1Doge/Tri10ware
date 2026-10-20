using UnityEditor.AnimatedValues;
using UnityEngine;

public class SniperEnemyVisual : MonoBehaviour
{
    private SniperEnemy sniperEnemy;

    private void Start()
    {
        sniperEnemy = GetComponentInParent<SniperEnemy>();
    }

    private void Update()
    {
        if (sniperEnemy.IsLockingOn()){
            float rotation = Mathf.Atan2(sniperEnemy.GetPlayerDirection().y, sniperEnemy.GetPlayerDirection().x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotation);

        }
    }
}
