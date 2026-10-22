using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private float healAmount;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            other.GetComponent<Health>().Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
