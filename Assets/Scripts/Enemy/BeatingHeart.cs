using System;
using UnityEngine;

public class BeatingHeart : Enemy
{
    public Action OnBeatingHeartKilled;
    [SerializeField] private Health health;
    [SerializeField] private MenuHandler menuHandler;

    private void Start()
    {
        health = GetComponent<Health>();
        menuHandler = FindAnyObjectByType<MenuHandler>();
        health.OnDeath += End;
    }
    private void End()
    {
        menuHandler.SwitchScene("EndCutscene");
    }
}
