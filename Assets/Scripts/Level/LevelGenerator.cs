using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] roomPrefabs;
    [SerializeField] private Vector3 generationOrigin;
    [SerializeField] private int numRooms;

    private List<GameObject> rooms;

    private void Start() {
        rooms = new List<GameObject>();
        generateLevel();
    }

    private void generateLevel() {
        Vector3 doorWayPosition = generationOrigin;
        for(int i = 0;i<numRooms;i++) {
            GameObject chosenRoom = roomPrefabs[Random.Range(0,roomPrefabs.Length)];
            Vector3 position = doorWayPosition + (chosenRoom.transform.position - chosenRoom.GetComponent<Room>().entrancePosition());
            GameObject newRoom = Instantiate(chosenRoom,position,Quaternion.Euler(0,0,0));

            rooms.Add(newRoom);
            doorWayPosition = newRoom.GetComponent<Room>().exitPosition();
        }
    }
}
