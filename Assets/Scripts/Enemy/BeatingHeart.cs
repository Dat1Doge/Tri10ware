using System;
using UnityEngine;

public class BeatingHeart : Enemy
{
    public Action OnBeatingHeartKilled;
    [SerializeField] private MenuHandler menuHandler;

    private void Start()
    {
        menuHandler = FindAnyObjectByType<MenuHandler>();
    }
    private void OnDestroy()
    {
        menuHandler.SwitchScene("EndCutscene");
        Debug.Log("End");
    }
}
