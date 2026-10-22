using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float lifeSpan;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,lifeSpan);
    }

    public void ChangeText(float damage) {
        text.text = "-"+damage;
    }
}
