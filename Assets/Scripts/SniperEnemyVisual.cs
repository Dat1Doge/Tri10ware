using UnityEngine;

public class SniperEnemyVisual : MonoBehaviour
{
    private SniperEnemy sniperEnemy;

    private void Start()
    {
        sniperEnemy = GetComponent<SniperEnemy>();
    }

    private void Update()
    {
        if (sniperEnemy.IsLockingOn()){
            //visuals and stuff
        }
    }
}
