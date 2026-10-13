using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Camera camera;

    private Vector3 mousePosition;
    private Vector3 aimVector;

    private void Start()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

        aimVector = (mousePosition - transform.position).normalized;
        float rotation = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotation - 90);
    }

    public Vector3 GetAimDirection()
    {
        return aimVector;
    }
}
