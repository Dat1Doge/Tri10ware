using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Transform entrance;
    [SerializeField] private Transform exit;

    public Vector3 exitPosition() {
        return exit.position;
    }
     
    public Vector3 entrancePosition() {
        return entrance.position;
    }
}
