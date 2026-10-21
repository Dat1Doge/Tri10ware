using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    private Health playerHealth;
    [SerializeField] private GameObject deathCanvas;

    private void HandleDeath() {
        deathCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        playerHealth.OnDeath += HandleDeath;
    }
}
