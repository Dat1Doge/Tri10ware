using UnityEngine;
using UnityEngine.UIElements;

public class CameraHandler : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float fovIncrease; //scales the camera effect that indicates the tempo
    
    private TempoHandler tempoHandler;

    private Camera cam;
    private float defaultSize;

    void Start()
    {
        cam = GetComponent<Camera>();
        defaultSize = cam.orthographicSize;

        tempoHandler = GameObject.FindGameObjectWithTag("TempoHandler").GetComponent<TempoHandler>();
        tempoHandler.OnTempoChange += UpdateFOV;
        UpdateFOV();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void UpdateFOV(){
        cam.orthographicSize = defaultSize + fovIncrease*tempoHandler.GetBPMmulti();
    }

    void FixedUpdate()
    {
        Vector3 targetPos = player.transform.position+new Vector3(0,0,-10);
        transform.position = Vector3.Lerp(transform.position,targetPos,Time.deltaTime*speed);
    }
}
