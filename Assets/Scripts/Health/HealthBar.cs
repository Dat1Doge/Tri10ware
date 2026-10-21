using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Health playerHealth;
    [SerializeField] private Slider slider;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        slider.maxValue = playerHealth.GetMaxHealth();
        UpdateUI();
        playerHealth.OnHealthChanged+=UpdateUI;
    }

    private void UpdateUI() {
        slider.value = playerHealth.GetCurrentHealth();
    }
}
