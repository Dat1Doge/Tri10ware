using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private List<SpawnPad> spawnPads;

    public void InitiateSpawners()
    {
        foreach (SpawnPad spawnPad in spawnPads)
        {
            spawnPad.Spawn();
        }
    }
}
