using UnityEngine;
using UnityEngine.UIElements;

public class Camera : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private float speed;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Vector3 targetPos = player.transform.position+new Vector3(0,0,-10);
        transform.position = Vector3.Lerp(transform.position,targetPos,Time.deltaTime*speed);
    }
}
