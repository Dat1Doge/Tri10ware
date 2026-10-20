using UnityEngine;

public class SpawnPad : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject editorVisual;

    private void Start()
    {
        editorVisual.SetActive(false);
    }

    public void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
