using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] roomPrefabs;
    [SerializeField] private Vector3 generationOrigin;
    [SerializeField] private int numRooms;
    [SerializeField] private GameObject bossRoom;

    private List<GameObject> rooms;

    private void Start() {
        rooms = new List<GameObject>();
        for(int i = 0; i<roomPrefabs.Length;i++) {
            rooms.Add(roomPrefabs[i]);
        }
        generateLevel();
    }

    private void generateLevel() {
        Vector3 doorWayPosition = generationOrigin;
        for(int i = 0;i<numRooms;i++) {
            int index = Random.Range(0,rooms.Count);
            GameObject chosenRoom = rooms[index];
            Vector3 position = doorWayPosition + (chosenRoom.transform.position - chosenRoom.GetComponent<Room>().entrancePosition());
            GameObject newRoom = Instantiate(chosenRoom,position,Quaternion.Euler(0,0,0));
            rooms.RemoveAt(index);
            
            doorWayPosition = newRoom.GetComponent<Room>().exitPosition();
        }
        Vector3 bossRoomPosition = doorWayPosition + (bossRoom.transform.position - bossRoom.GetComponent<Room>().entrancePosition());
        GameObject newBossRoom = Instantiate(bossRoom,bossRoomPosition,Quaternion.Euler(0,0,0));
    }
}
