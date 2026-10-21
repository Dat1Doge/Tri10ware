using UnityEngine;

public class SpawnPad : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject editorVisual;
    [SerializeField] private Door door;

    private void Start()
    {
        editorVisual.SetActive(false);
    }

    public void Spawn()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        if(door) {
            door.AddEnemy(newEnemy);
        }
    }
}
