using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health;

    public void SetHealth(float newhealth)
    {
        health = newhealth;
    }
    
}
