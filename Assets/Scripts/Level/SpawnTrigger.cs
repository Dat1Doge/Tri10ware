using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] private SpawnPad[] spawnPads;

    private void OnTriggerEnter2D() {
        foreach(SpawnPad pad in spawnPads) {
            pad.Spawn();
        }
        Destroy(gameObject);
    }
}
