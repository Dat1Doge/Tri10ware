using UnityEngine;

public class Door : MonoBehaviour
{
    private int enemiesLeft;

    private void EnemyDeath() {
        enemiesLeft--;
        if(enemiesLeft <= 0) {
            OpenDoor();
        }
    }

    public void AddEnemy(GameObject enemy) {
        enemy.GetComponent<Health>().OnDeath += EnemyDeath;
        enemiesLeft++;
    }

    private void OpenDoor() {
        Destroy(gameObject);
    }
}
