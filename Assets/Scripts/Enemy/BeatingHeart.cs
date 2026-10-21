using System;
using UnityEngine;

public class BeatingHeart : Enemy
{
    public Action OnBeatingHeartKilled;
    private void OnDestroy()
    {
        OnBeatingHeartKilled?.Invoke();
    }
}
