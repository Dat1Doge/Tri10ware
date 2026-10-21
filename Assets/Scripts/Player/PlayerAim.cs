using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Camera camera;
    [SerializeField] SpriteRenderer sr;

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
        transform.rotation = Quaternion.Euler(0,0,rotation);
        if(rotation < 90 && rotation > -90) {
            sr.flipY = false;
        }
        else{
            sr.flipY = true;
        }
    }

    public Vector3 GetAimDirection()
    {
        return aimVector;
    }
}
